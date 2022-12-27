using System.Data;
using Microsoft.Data.Sqlite;
using OmniaWebService.Services.Exceptions;
using OmniaWebService.Services.ValueTypes;

namespace OmniaWebService.Services.Infrastructure
{
public class SqliteDatabaseAccessor : IDatabaseAccessor
   {
      private readonly ILogger<SqliteDatabaseAccessor> logger;
      private readonly IConfiguration configuration;
      public SqliteDatabaseAccessor(ILogger<SqliteDatabaseAccessor> logger, IConfiguration configuration)
      {
         this.logger = logger;
         this.configuration = configuration;
      }

      public async Task<int> CommandAsync(FormattableString formattableCommand, CancellationToken token)
      {
         try
         {
            using SqliteConnection conn = await GetOpenedConnection(token);
            using SqliteCommand cmd = GetCommand(formattableCommand, conn);
            int affectedRows = await cmd.ExecuteNonQueryAsync(token);
            return affectedRows;
         }
         catch (SqliteException exc) when (exc.SqliteErrorCode == 19)
         {
            throw new ConstraintViolationException(exc);
         }
      }

      public async Task<T> QueryScalarAsync<T>(FormattableString formattableQuery, CancellationToken token)
      {
         try
         {
            using SqliteConnection conn = await GetOpenedConnection(token);
            using SqliteCommand cmd = GetCommand(formattableQuery, conn);
            object result = await cmd.ExecuteScalarAsync();
            return (T)Convert.ChangeType(result, typeof(T));
         }
         catch (SqliteException exc) when (exc.SqliteErrorCode == 19)
         {
            throw new ConstraintViolationException(exc);
         }
      }

      public async Task<DataSet> QueryAsync(FormattableString formattableQuery, CancellationToken token)
      {
         logger.LogInformation(formattableQuery.Format, formattableQuery.GetArguments());

         using SqliteConnection conn = await GetOpenedConnection(token);
         using SqliteCommand cmd = GetCommand(formattableQuery, conn);

         //Inviamo la query al database e otteniamo un SqliteDataReader
         //per leggere i risultati

         try
         {
            using var reader = await cmd.ExecuteReaderAsync(token);
            DataSet dataSet = new();

            //Creiamo tanti DataTable per quante sono le tabelle
            //di risultati trovate dal SqliteDataReader
            do
            {
               DataTable dataTable = new();
               dataSet.Tables.Add(dataTable);
               dataTable.Load(reader);
            } while (!reader.IsClosed);

            return dataSet;
         }
         catch (SqliteException exc) when (exc.SqliteErrorCode == 19)
         {
            throw new ConstraintViolationException(exc);
         }

      }



      private static SqliteCommand GetCommand(FormattableString formattableQuery, SqliteConnection conn)
      {
         //Creiamo dei SqliteParameter a partire dalla FormattableString
         var queryArguments = formattableQuery.GetArguments();
         List<SqliteParameter> sqliteParameters = new();
         for (var i = 0; i < queryArguments.Length; i++)
         {
            if (queryArguments[i] is Sql)
            {
               continue;
            }
            SqliteParameter parameter = new(name: i.ToString(), value: queryArguments[i] ?? DBNull.Value);
            /*
             * L'If seguente si rende necessario perch� nella query che utilizzo in ConsuntivoSpese.cshtml per filtrare i risultati
             * viene utilizzata la like che fa casino con il passaggio di parametri utilizzato nella formattableString.
             * Per ora va bene cos� perch� � solo una pagina che ne fa uso!!!!!
             */
            if (i == 0 && formattableQuery.ToString().Contains("LIKE"))
            {
               parameter.Value = "%" + parameter.Value + "%";
               sqliteParameters.Add(parameter);
            }
            else
            {
               sqliteParameters.Add(parameter);
            }
            queryArguments[i] = "@" + i;
         }
         string query = formattableQuery.ToString();

         SqliteCommand cmd = new(query, conn);
         //Aggiungiamo i SqliteParameters al SqliteCommand
         cmd.Parameters.AddRange(sqliteParameters);
         return cmd;
      }

      private async Task<SqliteConnection> GetOpenedConnection(CancellationToken token)
      {
         //Colleghiamoci al database Sqlite, inviamo la query e leggiamo i risultati
         
         string connectionString = configuration["ConnectionStrings:Default"];
         SqliteConnection conn = new(connectionString);
         await conn.OpenAsync(token);
         return conn;
      }

      public bool IsEmpty(string QRY)
      {
         string connectionString = configuration["ConnectionStrings:Default"];
         using (SqliteConnection _conn = new SqliteConnection(connectionString))
         {
            _conn.Open();
            using (SqliteCommand _comm = new SqliteCommand(QRY, _conn))
            {
               using (SqliteDataReader _reader = _comm.ExecuteReader())
               {
                  if (_reader.HasRows)
                  {
                     return false;
                  }
                  else
                  {
                     return true;
                  }
               }
            }
         }
      }
   }   
}
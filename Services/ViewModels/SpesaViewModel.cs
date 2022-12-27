using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OmniaWebService.Services.ViewModels
{
public class SpesaViewModel
    {
        public int SpesaID { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }
        public decimal ResiduoMese { get; set; }
        [Range(1, 100)]
        public int GiornoPagamento { get; set; }
        public char Tipo { get; set; }

        public static SpesaViewModel FromDataRows(DataRow Spese)
        {

            //Metodo che utilizzo per la mappatura tra i dati letti dal Db e il ViewModel
            SpesaViewModel spesaViewModel = new SpesaViewModel
            {
                SpesaID = Convert.ToInt32(Spese["ID"]),
                Descrizione = Spese["Descrizione"].ToString(),
                Importo = Convert.ToDecimal(Spese["Importo"]),
                ResiduoMese = Convert.ToDecimal(Spese["ResiduoMese"]),
                GiornoPagamento = (Spese["GiornoPagamento"] != DBNull.Value) ? Convert.ToInt16(Spese["GiornoPagamento"]) : 0,
                Tipo = Convert.ToChar(Spese["Tipo"]),
            };
            return spesaViewModel;
        }
    }   
}
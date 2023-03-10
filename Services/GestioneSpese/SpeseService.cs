using Microsoft.EntityFrameworkCore;
using OmniaWebService.Models;
using OmniaWebService.Services.InputModels;
using OmniaWebService.Services.ViewModels;

namespace OmniaWebService.Services.GestioneSpese
{
   public class SpeseService : ISpeseService
   {
      private readonly OmniaDbContext omniaDbContext;
      public SpeseService(OmniaDbContext omniaDbContext)
      {
         this.omniaDbContext = omniaDbContext;   
      }
      public Task<DettaglioSpesaViewModel> CreaDettaglioAsync(SpesaConsuntivaInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public Task<SpesaViewModel> CreaSpesaAsync(SpesaCreateInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public Task DeleteCourseAsync(SpesaDeleteInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public Task<List<DettaglioSpesaViewModel>> DettaglioSpeseMensili(string mioFiltro = "")
      {
         throw new NotImplementedException();
      }

      public Task<DettaglioSpesaViewModel> EditConsuntivoSpesaAsync(SpesaConsuntivaInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public Task<SpesaViewModel> EditSpesaAsync(SpesaEditInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public Task<SpesaConsuntivaInputModel> GetDettaglioSpesaForEditingAsync(int id)
      {
         throw new NotImplementedException();
      }

      public async Task<IEnumerable<DettaglioSpese>> getDettaglioSpeseAsync(string descrizione)
      {
         // return await this.omniaDbContext.Spese
         //    .Where(a=>a.Descrizione.Contains(descrizione))
         //    .OrderBy(a=>a.Descrizione)
         //    .ToListAsync();

         return await this.omniaDbContext.DettaglioSpese
            .Where(a=>a.Descrizione.Contains(descrizione))
            .OrderBy(a=>a.DataSpesa)
            .ToListAsync();
      }

      public async Task<IEnumerable<SaldiCC>> getSaldiAsync()
      {
         return await this.omniaDbContext.SaldiCC
            .OrderBy(a => a.DataOraAggiornamento)
            .ToListAsync();
      }

      //public async Task<SaldiCC> GetSaldoAsync()
      public async Task<decimal> GetSaldoAsync()
      {
         return await this.omniaDbContext.SaldiCC
            .OrderByDescending(a => a.DataOraAggiornamento)
            .Select(p=>p.Saldo)
            .FirstOrDefaultAsync();
      }
      public async Task<decimal> GetTotaleSpeseAsync()
      {

         return await omniaDbContext.Spese.Where(y=>y.Status == 1).Select(x => x.Importo).SumAsync();
         
      }

      public async Task<double> GetTotaleAccantonamentiAsync()
      {
         return await omniaDbContext.Accantonamenti.Where(y=>y.Status == 1).Select(x => x.TotaleAccantonato).SumAsync();
      }

      public Task<SpesaViewModel> GetSpesaAsync(int id)
      {
         throw new NotImplementedException();
      }

      public Task<SpesaEditInputModel> GetSpesaForEditingAsync(int id)
      {
         throw new NotImplementedException();
      }

      public Task<List<SpesaViewModel>> GetSpeseAsync()
      {
         throw new NotImplementedException();
      }



      public Task ResetAsync()
      {
         throw new NotImplementedException();
      }

      public Task SetCCAsync(CCUpdateInputModel inputModel)
      {
         throw new NotImplementedException();
      }

      public async Task<bool> SpesaExistsAsync(string descrizione)
      {
         return await this.omniaDbContext.DettaglioSpese
            .AnyAsync(a=>a.Descrizione.Contains(descrizione));
      }


   }
}
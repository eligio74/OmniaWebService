using OmniaWebService.Models;
using OmniaWebService.Services.InputModels;
using OmniaWebService.Services.ViewModels;

namespace OmniaWebService.Services.GestioneSpese
{
public interface ISpeseService
    {
        Task <bool> SpesaExistsAsync(string descrizione);
        Task<decimal> GetSaldoAsync();
        Task<decimal> GetTotaleSpeseAsync();
        Task<double> GetTotaleAccantonamentiAsync();
        Task<List<SpesaViewModel>> GetSpeseAsync();
        Task<SpesaViewModel> CreaSpesaAsync(SpesaCreateInputModel inputModel);
        Task<DettaglioSpesaViewModel> CreaDettaglioAsync(SpesaConsuntivaInputModel inputModel);
        Task<SpesaViewModel> GetSpesaAsync(int id);
        Task<SpesaEditInputModel> GetSpesaForEditingAsync(int id);
        Task<SpesaConsuntivaInputModel> GetDettaglioSpesaForEditingAsync(int id);
        Task<SpesaViewModel> EditSpesaAsync(SpesaEditInputModel inputModel);
        Task<DettaglioSpesaViewModel> EditConsuntivoSpesaAsync(SpesaConsuntivaInputModel inputModel);
        Task DeleteCourseAsync(SpesaDeleteInputModel inputModel);
        Task SetCCAsync(CCUpdateInputModel inputModel);
        Task ResetAsync();
        Task<List<DettaglioSpesaViewModel>> DettaglioSpeseMensili(string mioFiltro="");
        Task<IEnumerable<SaldiCC>> getSaldiAsync();
        // Task<SaldiCC> GetSaldoAsync();
        Task<IEnumerable<DettaglioSpese>> getDettaglioSpeseAsync(string descrizione);
    }   
}
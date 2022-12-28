using Microsoft.AspNetCore.Mvc;
using OmniaWebService.Dtos;
using OmniaWebService.Services.InputModels;
using OmniaWebService.Services.GestioneSpese;

namespace OmniaWebService.Controllers
{
   [ApiController] //indica che questo è un controller di una Web Api
   [Produces("application/json")] //quello che la WebApi produrrà, in questo caso un formato di tipo Json
   [Route("api/saldo")] //specifichiamo la route di base   
   public class SpeseController: Controller
      {
      private readonly ISpeseService SpeseService;    
      public SpeseController(ISpeseService speseService)
      {
         this.SpeseService = speseService;
      } 

      //[HttpGet("cerca/saldo/")]
      [HttpGet("GetSaldo/")]
      [ProducesResponseType(400)]
      [ProducesResponseType(404)]
      [ProducesResponseType(200, Type = typeof(SaldiDto))]
      public async Task<IActionResult> GetSaldi()
      {
         var saldiDto = new List<SaldiDto>();
         var saldi = await SpeseService.getSaldiAsync();

         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }


         //Per il codice di errore 404 (Not Found)
         //if (saldi.Count==0)
         //{
         //   return NotFound("Non è stato trovato alcun Saldo nel dB");
         //}

         foreach (var saldo in saldi)
         {
            saldiDto.Add(new SaldiDto{
               Mese = saldo.Mese,
               Anno=saldo.Anno,
               Saldo=saldo.Saldo,
               DataOraAggiornamento=saldo.DataOraAggiornamento
            });  
         }
         
         return Ok(saldiDto);

      }

      [HttpGet("Cerca/Spesa/{descrizione}")]
      [ProducesResponseType(400)]
      [ProducesResponseType(404)]
      [ProducesResponseType(200, Type = typeof(DettaglioSpeseDto))]
      public async Task<IActionResult> GetDettaglioSpese(string descrizione)
      {
         bool retVal = await SpeseService.SpesaExistsAsync(descrizione);
         if (!retVal)
         {
            return NotFound(string.Format($"Non è stata trovata nessuna spesa con il parametro {descrizione}"));            
         }

         var dettaglioSpeseDto = new List<DettaglioSpeseDto>();
         var spese = await SpeseService.getDettaglioSpeseAsync(descrizione);

         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         foreach (var spesa in spese)
         {
            dettaglioSpeseDto.Add(new DettaglioSpeseDto 
            {
               DataSpesa=spesa.DataSpesa,
               Importo=spesa.Importo,
               Descrizione=spesa.Descrizione,
               Spesa=spesa.Spesa
            });

         }
         return Ok(dettaglioSpeseDto); 
      }
      
      [HttpGet("GetSaldoContabile")]
      [ProducesResponseType(400)]
      [ProducesResponseType(404)]
      [ProducesResponseType(200, Type = typeof(decimal))]
      public async Task<IActionResult> GetSaldoContabile()
      {
         
         decimal saldo = await SpeseService.GetSaldoAsync();

         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         return Ok(saldo);
      }

      [HttpGet("GetTotaleSpese")]
      [ProducesResponseType(400)]
      [ProducesResponseType(404)]
      [ProducesResponseType(200, Type = typeof(decimal))]
      public async Task<IActionResult> GetTotaleSpese()
      {
         
         decimal totaleSpese = await SpeseService.GetTotaleSpeseAsync();

         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         return Ok(totaleSpese);
      }

   }
}
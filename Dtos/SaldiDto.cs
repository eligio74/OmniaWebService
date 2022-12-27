namespace OmniaWebService.Dtos
{
   public class SaldiDto
   {
      // In questa classe inserisco solo i campi che voglio visualizzare
      public string Mese { get; set; }
      public int Anno { get; set; }
      public decimal Saldo { get; set; }
      public string DataOraAggiornamento { get; set; }
   }
}
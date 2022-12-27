namespace OmniaWebService.Dtos
{
   public class SpeseDto
   {
      public string Descrizione { get; set; }
      public decimal Importo { get; set; }
      public decimal ResiduoMese { get; set;}
      public int GiornoPagamento { get; set; }
      public string Tipo { get; set; }
   }
}
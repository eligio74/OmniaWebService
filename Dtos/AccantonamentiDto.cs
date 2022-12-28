namespace OmniaWebService.Dtos
{
   public class AccantonamentiDto
   {
      public string Descrizione { get; set; }
      public double CostoAnnuale { get; set; }
      public int MesiAccantonati { get; set; }
      public double TotaleAccantonato { get; set; }
      public string DataOraAggiornamento { get; set; }
      public int status { get; set; }     
   }
}
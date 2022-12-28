using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Models
{
   public class Accantonamenti {
      [Key]
      public int Id { get; set; }
      public string Descrizione { get; set; }
      public double CostoAnnuale { get; set; }
      public int MesiAccantonati { get; set; }
      public double TotaleAccantonato { get; set; }
      public string DataOraAggiornamento { get; set; }
      public int Status { get; set; }
      
   }
}
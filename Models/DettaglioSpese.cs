using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Models
{
   public class DettaglioSpese {
      [Key]
      public int Id { get; set; }
      public string DataSpesa { get; set; }
      public string Spesa { get; set; }
      public string Descrizione { get; set; }
      public decimal Importo { get; set; }
      public int Status { get; set; }
   }
}
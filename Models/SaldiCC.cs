using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Models
{
   public class SaldiCC {
      [Key]
      public int Id { get; set; }
      public string Mese { get; set; }
      public int Anno { get; set; }
      public decimal Saldo { get; set; }
      public int Status { get; set; }
      public string DataOraAggiornamento { get; set; }
   }
}
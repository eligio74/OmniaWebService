using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Models
{
   public class Spese
   {
      [Key]
      public int Id { get; set; }
      public string Descrizione { get; set; }
      public decimal Importo { get; set; }
      public decimal ResiduoMese { get; set;}
      public int GiornoPagamento { get; set; }
      public string Tipo { get; set; }
      public int Status { get; set; }
   }
}
using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Services.InputModels
{
    public class CCUpdateInputModel
    {
        [Required]
        public decimal Saldo { get; set; }
    }  
}
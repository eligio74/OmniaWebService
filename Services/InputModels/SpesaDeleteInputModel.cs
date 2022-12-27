using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Services.InputModels
{
   public class SpesaDeleteInputModel
    {
        [Required]
        public int Id { get; set; }
    }   
}
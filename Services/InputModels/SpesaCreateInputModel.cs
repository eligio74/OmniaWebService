using System.ComponentModel.DataAnnotations;

namespace OmniaWebService.Services.InputModels
{
public class SpesaCreateInputModel
    {
        [Required(ErrorMessage = "La descrizione è obbligatoria"),
        MinLength(3, ErrorMessage = "La descrizione dev'essere di almeno {1} caratteri"),
        MaxLength(100, ErrorMessage = "La descrizione dev'essere di al massimo {1} caratteri")]
        //Remote(action: nameof(CoursesController.IsTitleAvailable), controller: "Courses", ErrorMessage = "Il titolo esiste già")]
        public string Descrizione { get; set; }

        [DataType(DataType.Currency)]
        public decimal Importo { get; set; }
        [DataType(DataType.Currency)]
        public decimal ResiduoMese { get; set; }

        public int? GiornoPagamento { get; set; }

        [Required(ErrorMessage = "Il Tipo Spesa è obbligatorio"),
        MinLength(1, ErrorMessage = "Il titolo dev'essere di almeno {1} caratteri"),
        MaxLength(1, ErrorMessage = "Il titolo dev'essere di al massimo {1} caratteri")]
        public string TipoSpesa { get; set; }
    }   
}
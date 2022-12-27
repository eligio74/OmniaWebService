using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OmniaWebService.Services.InputModels
{
public class SpesaEditInputModel
    //public class SpesaEditInputModel : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descrizione della spesa è obbligatoria"),
         MinLength(3, ErrorMessage = "La descrizione della spesa dev'essere di almeno {1} caratteri"),
         MaxLength(100, ErrorMessage = "La descrizione della spesa dev'essere di al massimo {1} caratteri"),
         Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [DataType(DataType.Currency)]
        public decimal Importo { get; set; }
        [DataType(DataType.Currency)]
        public decimal ResiduoMese { get; set; }

        public int? GiornoPagamento { get; set; }

        [Required(ErrorMessage = "Il Tipo Spesa è obbligatorio"),
        MinLength(1, ErrorMessage = "Il Tipo dev'essere di almeno {1} caratteri"),
        MaxLength(1, ErrorMessage = "Il Tipo dev'essere di al massimo {1} caratteri")]
        public string TipoSpesa { get; set; }



        public static SpesaEditInputModel FromDataRow(DataRow spesaRow)
        {
            SpesaEditInputModel spesaEditInputModel = new()
            {
                Id = Convert.ToInt32(spesaRow["ID"]),
                Descrizione = Convert.ToString(spesaRow["Descrizione"]),
                Importo = Convert.ToDecimal(spesaRow["Importo"]),
                ResiduoMese = Convert.ToDecimal(spesaRow["ResiduoMese"]),
                GiornoPagamento = (spesaRow["GiornoPagamento"] != DBNull.Value) ? Convert.ToInt16(spesaRow["GiornoPagamento"]) : 0,
                TipoSpesa = spesaRow["Tipo"].ToString()
            };
            return spesaEditInputModel;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                return null;
            }
            var property = validationContext.ObjectType.GetProperty(Descrizione);
            if (property == null)
            {
                //return new ValidationResult($"{_nameOfBoolProp} not found");
            }
            
            //var boolVal = property.GetValue(validationContext.ObjectInstance, null);

            //if (boolVal == null || boolVal.GetType() != typeof(bool))
            //{
            //    return new ValidationResult($"{_nameOfBoolProp} not boolean");
            //}

            //if ((bool)boolVal)
            //{
            //    var attribute = new EmailAddressAttribute { ErrorMessage = $"{value} is not a valid e-mail address." };
            //    return attribute.GetValidationResult(value, validationContext);
            //}
            return null;
        }
    }   
}
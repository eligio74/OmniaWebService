using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OmniaWebService.Services.InputModels
{
public class SpesaConsuntivaInputModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "La spesa è obbligatoria")]
        public DateTime DataSpesa { get; set; }
        
        [Required(ErrorMessage = "La spesa è obbligatoria"),
        MinLength(3, ErrorMessage = "La spesa dev'essere di almeno {1} caratteri"),
        MaxLength(100, ErrorMessage = "La spesa dev'essere di al massimo {1} caratteri")]
        public string Spesa { get; set; }

        [DataType(DataType.Currency)]
        public decimal Importo { get; set; }

        public string Descrizione { get; set; }

        public static SpesaConsuntivaInputModel FromDataRow(DataRow spesaRow)
        {
            SpesaConsuntivaInputModel spesaEditInputModel = new()
            {
                Id = Convert.ToInt32(spesaRow["ID"]),
                DataSpesa = Convert.ToDateTime(spesaRow["DataSpesa"]),
                Spesa = Convert.ToString(spesaRow["Spesa"]),
                Descrizione = Convert.ToString(spesaRow["Descrizione"]),
                Importo = Convert.ToDecimal(spesaRow["Importo"])
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
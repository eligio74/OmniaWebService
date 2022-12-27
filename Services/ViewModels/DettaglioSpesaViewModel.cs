using System.Data;

namespace OmniaWebService.Services.ViewModels
{
public class DettaglioSpesaViewModel
    {
        public int SpesaID { get; set; }
        public DateTime DataSpesa { get; set; }
        public string Spesa { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }


        public static DettaglioSpesaViewModel FromDataRows(DataRow Spese)
        {

            //Metodo che utilizzo per la mappatura tra i dati letti dal Db e il ViewModel
            DettaglioSpesaViewModel spesaViewModel = new DettaglioSpesaViewModel
            {
                SpesaID = Convert.ToInt32(Spese["ID"]),
                DataSpesa = Convert.ToDateTime(Spese["DataSpesa"]),
                Spesa = Spese["Spesa"].ToString(),
                Descrizione = Spese["Descrizione"].ToString(),
                Importo = Convert.ToInt64(Spese["Importo"]),
            };
            return spesaViewModel;
        }
    }   
}
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransportesMR.ViewModels
{
    public class CamionMarcaVM 
    {
        public Camion Camion { get; set; }

        public ModeloVehiculo IdModelo { get; set; }

        public IEnumerable<SelectListItem> ListaMarca { get; set; }
        public IEnumerable<SelectListItem> ListaModelo { get; set; }

    }
}

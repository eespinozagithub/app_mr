using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Models;

namespace TransportesMR.ViewModels
{
    public class MarcaModeloVM
    {
        public ModeloVehiculo ModeloVehiculo { get; set; }

        //public MarcaVehiculo MarcaVehiculo { get; set; }
        public IEnumerable<SelectListItem> ListaMarca { get; set; }
       


    }
}
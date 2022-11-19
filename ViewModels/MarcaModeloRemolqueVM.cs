using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransportesMR.ViewModels
{
    public class MarcaModeloRemolqueVM
    {
        public ModeloRemolque ModeloRemolque { get; set; }
        public IEnumerable<SelectListItem> ListaMarcaRemolque { get; set; }

    }
}

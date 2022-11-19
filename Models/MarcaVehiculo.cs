
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransportesMR.Models
{
    public class MarcaVehiculo
    {
        [Key]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100)]
        public string Marca { get; set; }

        //public IEnumerable<SelectListItem> ListaMarca { get; set; }
    }
}

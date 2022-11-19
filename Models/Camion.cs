using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransportesMR.Models
{
    public class Camion : Vehiculo
    {
        [Required(ErrorMessage = "Debe ingresar el Número de Camión")]
        [Display(Name = "N° Camion")]
        public int IdCamion { get; set; }

        public float Cilindrada { get; set; }
    }
}

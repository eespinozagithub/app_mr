using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransportesMR.Models
{
    public class Camion
    {
        [Key]
        [Display(Name = "ID")]
        public int IdCamion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Número de Camión")]
        [Display(Name = "N° Camion")]
        public int? NumeroCamion { get; set; }

        [Required(ErrorMessage = "Debe ingresar la patente")]
        [Display(Name = "Patente")]
        [MaxLength(10)]
        public string Patente { get; set; }

        [Display(Name = "N° Motor")]
        [MaxLength(100)]
        public string NumeroMotor { get; set; }

        [Display(Name = "N° Chasis")]
        [MaxLength(100)]
        public string Chasis { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Año")]
        [Display(Name = "Año")]
        [Range(1980, 2050)]
        public int? Anio { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Debe ingresar Color")]
        [Display(Name = "Color")]
        public string Color { get; set; }                
        
        public float? Cilindrada { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public int? Estado { get; set; }               

        [ForeignKey("ModeloVehiculo")]
        [Required(ErrorMessage = "Debe ingresar el Modelo")]
        [Display(Name = "Modelo")]
        public int? IdModelo { get; set; }

        public ModeloVehiculo? ModeloVehiculo { get; set; }
    }
}

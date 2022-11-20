namespace TransportesMR.Models
{
    public class Remolque
    {
        [Key]
        [Display(Name = "ID")]
        public int IdRemolque { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Número de Remolque")]
        [Display(Name = "N° Remolque")]
        public int? NumeroRemolque { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Patente")]
        [MaxLength(10)]
        public string Patente { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Capacidad")]
        public int? Capacidad { get; set; }

        [MaxLength(60)]
        [Required(ErrorMessage = "Debe ingresar el Número de Chasis")]
        [Display(Name = "Número de Chasis")]
        public string NumeroChasis { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Año")]
        [Display(Name = "Año")]
        [Range(1980,2050)]
        public int? Anio { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Tipo de Remolque")]
        [Display(Name = "Tipo Remolque")]
        public int? TipoRemolque { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Estado")]
        public bool Estado { get; set; }

        [ForeignKey("ModeloRemolque")]
        [Required(ErrorMessage = "Debe ingresar el Modelo")]
        [Display(Name="Modelo Remolque")]
        public int? IdModelo { get; set; }
        public ModeloRemolque? ModeloRemolque { get; set; }
    }
}
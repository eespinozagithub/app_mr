namespace TransportesMR.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }

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

        [Required(ErrorMessage = "Debe ingresar el año")]
        [Display(Name = "Año")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? Año { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Debe ingresar Color")]
        [Display(Name = "Color")]
        public string Color { get; set; }


        [ForeignKey("MarcaVehiculo")]
        [Display(Name = "Marca")]
        public int? IdMarca { get; set; }

        public MarcaVehiculo? MarcaVehiculo { get; set; }

        [ForeignKey("ModeloVehiculo")]
        [Display(Name = "Modelo")]
        public int? IdModelo { get; set; }

        public ModeloVehiculo? ModeloVehiculo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public int? Estado { get; set; }

    }
}

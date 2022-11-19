namespace TransportesMR.Models
{
    public class Remolque
    {
        [Key]
        [Display(Name = "ID")]
        public int IdRemolque { get; set; }

        [Required]
        [Display(Name = "Número Remolque")]
        public int NumeroRemolque { get; set; }

        [Required]
        [MaxLength(10)]
        public string Patente { get; set; }

        public int Capacidad { get; set; }

        [MaxLength(60)]
        [Display(Name = "Número de Chasis")]
        public string NumeroChasis { get; set; }

        public int Modelo { get; set; }

        [Required]
        [Display(Name = "Año")]
        public DateTime Anio { get; set; }

        [Display(Name = "Tipo Remolque")]
        public int TipoRemolque { get; set; }

        [Required]
        public bool Estado { get; set; }

    }
}
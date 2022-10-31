namespace TransportesMR.Models
{
    public class Remolque
    {
        [Key]
        public int IdRemolque { get; set; }

        [Required]
        [MaxLength(10)]
        public string Patente { get; set; }
        public string CapacidadRemolque { get; set; }

        [Required]
        public DateTime Año { get; set; }

        [MaxLength(100)]
        public string Color { get; set; }
        [Required]
        public int NumeroRemolque { get; set; }

        [Required]
        public bool Estado { get; set; }

        [ForeignKey("TipoRemolque")]
        [Required]
        public int IdTipoRemolque { get; set; }
        public TipoRemolque? TipoRemolque { get; set; }

    }
}
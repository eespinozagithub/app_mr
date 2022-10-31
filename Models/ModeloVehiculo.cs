namespace TransportesMR.Models
{
    public class ModeloVehiculo
    {
        [Key]
        [Required]
        public int IdModelo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Modelo { get; set; }

        [ForeignKey("MarcaVehiculo")]
        [Required]
        public int IdMarca { get; set; }
        public MarcaVehiculo? MarcaVehiculo { get; set; }
    }
}



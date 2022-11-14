namespace TransportesMR.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }

        [Required]
        [MaxLength(10)]
        public string Patente { get; set; }


        [MaxLength(100)]
        public string NumeroMotor { get; set; }


        [MaxLength(100)]
        public string Chasis { get; set; }

        [Required]
        public DateTime Año { get; set; }

        [MaxLength(100)]
        public string Color { get; set; }

        [Required]
        public bool Estado { get; set; }


        [ForeignKey("MarcaVehiculo")]
     
        public int? IdMarca { get; set; }

        public MarcaVehiculo? MarcaVehiculo { get; set; }

        [ForeignKey("ModeloVehiculo")]
        [Required]
        public int? IdModelo { get; set; }

        public ModeloVehiculo? ModeloVehiculo { get; set; }

    }
}

namespace TransportesMR.Models
{
    public class Ciudades
    {
        [Key]
        [Display(Name = "ID")]
        public int IdCiudad { get; set; }

        [Required(ErrorMessage = "Debe ingresar la ciudad o región")]
        [MaxLength(100)]
        public string Ciudad { get; set; }

        [Required]
        public bool Estado { get; set; }

        public List<Vueltas>? CiudadCarga { get; set; }
        public List<Vueltas>? CiudadDescarga { get; set; }
    }
}

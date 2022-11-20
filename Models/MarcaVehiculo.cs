namespace TransportesMR.Models
{
    public class MarcaVehiculo
    {
        [Key]
        [Display(Name = "ID")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "Debe ingresar la marca")]
        [MaxLength(100)]
        public string Marca { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}

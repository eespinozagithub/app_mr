namespace TransportesMR.Models
{
    public class MarcaRemolque
    {
        [Key]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "Debe ingresar la marca")]
        [MaxLength(100)]
        public string Marca { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}

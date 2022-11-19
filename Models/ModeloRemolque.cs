namespace TransportesMR.Models
{
    public class ModeloRemolque
    {
        [Key]
        [Required]
        public int IdModelo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el modelo")]
        [MaxLength(100)]
        public string Modelo { get; set; }

        [Required]
        public bool Estado { get; set; }

        [ForeignKey("MarcaRemolque")]
        [Display(Name = "Marca Remolque")]
        [Required(ErrorMessage = "Debe seleccionar el modelo")]        
        public int IdMarca { get; set; }

        //[Display(Name = "Marca Remolque")]
        public MarcaRemolque? MarcaRemolque { get; set; }
       
    }
}

namespace TransportesMR.Models
{
    public class TipoRemolque
    {
        [Key]
        public int IdTipoRemolque { get; set; }
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        public float capacidad { get; set; }
    }
}

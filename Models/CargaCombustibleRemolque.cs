namespace TransportesMR.Models
{
    public class CargaCombustibleRemolque
    {
        [Key]
        [Required(ErrorMessage = "Debe ingresar un remolque")]
        public int IdCargaCombustibleRemolque { get; set; }

        [ForeignKey("Remolque")]
        [Required]
        public int IdRemolque { get; set; }
        public Remolque? Remolque { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el combustible")]
        public int? Combustible { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de carga")]
        [Display(Name = "Fecha carga")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? FechaCargaCombustible { get; set; }

        [Required(ErrorMessage = "Debe ingresar los litros")]
        [Display(Name = "Litros")]
        public decimal Litros { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el lugar de carga")]
        [Display(Name = "Lugar Carga")]
        public int? LugarCarga { get; set; }

        [Display(Name = "Factura Carga")]
        public int? FacturaCarga { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio")]
        [Display(Name = "Precio Litros")]
        public decimal PrecioLitros { get; set; }
    }
}

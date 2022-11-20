namespace TransportesMR.Models
{
    public class CargaCombustible
    {
        [Key]
        [Required(ErrorMessage = "Debe ingresar un camión")]
        public int IdCargaCombustible { get; set; }

        [ForeignKey("MarcaVehiculo")]
        [Required]
        public int IdCamion { get; set; }
        public Camion? Camion { get; set; }

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

        [Required(ErrorMessage = "Debe ingresar el kilometraje")]
        [Display(Name = "Kilometraje")]
        public decimal Kilometraje { get; set; }

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

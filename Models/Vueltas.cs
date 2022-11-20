namespace TransportesMR.Models
{
    public class Vueltas
    {
        [Key]
        public int IdVueltas { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Salida")]
        [Display(Name = "Fecha Salida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? FechaSalida { get; set; }

        //[Required(ErrorMessage = "Debe ingresar la Fecha de Salida")]
        //[Display(Name = "Fecha Salida")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        //[DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        //public DateTime? FechaLlegada { get; set; }

        [ForeignKey("Camion")]
        [Required]
        public int IdCamion { get; set; }
        public Camion? Camion { get; set; }

        //[ForeignKey("Remolque")]
        //[Display(Name = "Remolque")]
        //public int IdRemolque { get; set; }
        //public Remolque? Remolque { get; set; }

        //[Display(Name = "Sentido")]
        //[Required(ErrorMessage = "Debe seleccionar un Sentido")]
        //public int Sentido { get; set; }

        //[ForeignKey("Trabajador")]
        //[Display(Name = "Conductor 1")]
        //[Required(ErrorMessage = "Debe seleccionar un conductor")]
        //public int IdTrabajador { get; set; }

        //[ForeignKey("Trabajador")]
        //[Display(Name = "Conductor 2")]
        //public int? IdTrabajadorApoyo { get; set; }

        //public Trabajador? Trabajador { get; set; }

        //[Display(Name = "Factura")]
        //public int? Factura1 { get; set; }

        //[Display(Name = "Factura")]
        //public int? Factura2 { get; set; }

        //[Display(Name = "Factura")]
        //public int? Factura3 { get; set; }

        //[ForeignKey("Empresa")]
        //[Display(Name = "Empresa Responsable")]
        //[Required(ErrorMessage = "Debe seleccionar una empresa")]
        //public int IdEmpresaResponsable { get; set; }

        //[ForeignKey("Empresa")]
        //[Display(Name = "Empresa Carga")]
        //[Required(ErrorMessage = "Debe seleccionar una empresa")]
        //public int IdEmpresaCarga { get; set; }

        //[ForeignKey("Empresa")]
        //[Display(Name = "Empresa Descarga")]
        //[Required(ErrorMessage = "Debe seleccionar una empresa")]
        //public int IdEmpresaDescarga { get; set; }

        //public Empresa? Empresa { get; set; }

        //[ForeignKey("Regiones")]
        //[Required(ErrorMessage = "Debe ingresar region de carga")]
        //[Display(Name = "Region Carga")]
        //public int? IdRegionCarga { get; set; }

        //[ForeignKey("Regiones")]
        //[Required(ErrorMessage = "Debe ingresar region de descarga")]
        //[Display(Name = "Region Carga")]
        //public int? IdRegionDescarga { get; set; }

        //public Ciudades? Ciudades { get; set; }

        //[Required(ErrorMessage = "Debe ingresar el valor del viaje")]
        //[Display(Name = "Valor Viaje")]
        //public decimal? ValorViaje { get; set; }

        //[Required(ErrorMessage = "Debe ingresar el porcentaje de conductor")]
        //[Display(Name = "Valor Viaje")]
        //public decimal? PorcentajeConductor { get; set; }

        //[Required(ErrorMessage = "Debe ingresar viatico")]
        //[Display(Name = "Viatico Transferido")]
        //public decimal ViaticoTransferido { get; set; }

        //[Required(ErrorMessage = "Debe ingresar viatico gastado")]
        //[Display(Name = "Viatico Gastado")]
        //public decimal ViaticoGastado { get; set; }

        //public string? Observacion { get; set; }

    }

}

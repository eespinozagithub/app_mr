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

        [Required(ErrorMessage = "Debe ingresar la Fecha de Salida")]
        [Display(Name = "Fecha Llegada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? FechaLlegada { get; set; }

        [ForeignKey("Camion")]
        [Display(Name = "Camion")]
        [Required]
        public int IdCamion { get; set; }
        [Display(Name = "Camion")]
        public Camion? Camion { get; set; }

        [ForeignKey("Remolque")]
        [Display(Name = "Remolque")]
        public int IdRemolque { get; set; }
        [Display(Name = "Remolque")]
        public Remolque? Remolque { get; set; }

        [Display(Name = "Sentido")]
        [Required(ErrorMessage = "Debe seleccionar un Sentido")]
        public int Sentido { get; set; }

        [ForeignKey("Trabajador")]
        [Display(Name = "Conductor")]
        [Required(ErrorMessage = "Debe seleccionar un conductor")]
        public int IdTrabajador { get; set; }

        public Trabajador? Trabajador { get; set; }

        [Display(Name = "Factura")]
        public int? Factura1 { get; set; }

        [Display(Name = "Factura")]
        public int? Factura2 { get; set; }

        [Display(Name = "Factura")]
        public int? Factura3 { get; set; }

        //[ForeignKey("Empresa")]
        [Display(Name = "Empresa Responsable")]
        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        public int? IdEmpresaResponsable { get; set; }
        [Display(Name = "Empresa Responsable")]
        public Empresa? EmpresaResponsable { get; set; }

        //[ForeignKey("Empresa")]
        [Display(Name = "Empresa Carga")]
        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        public int? IdEmpresaCarga { get; set; }
        [Display(Name = "Empresa Carga")]
        public Empresa? EmpresaCarga { get; set; }

        //[ForeignKey("Empresa")]
        [Display(Name = "Empresa Descarga")]
        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        public int? IdEmpresaDescarga { get; set; }
        [Display(Name = "Empresa Descarga")]
        public Empresa? EmpresaDescarga { get; set; }

        [Required(ErrorMessage = "Debe ingresar region de carga")]
        [Display(Name = "Ciudad Carga")]
        public int? IdCiudadCarga { get; set; }
        public Ciudades? CiudadCarga { get; set; }


        [Required(ErrorMessage = "Debe ingresar region de descarga")]
        [Display(Name = "Ciudad Descarga")]
        public int? IdCiudadDescarga { get; set; }
        [Display(Name = "Ciudad Descarga")]
        public Ciudades? CiudadDescarga { get; set; }

        [Required(ErrorMessage = "Debe ingresar el valor del viaje")]
        [Display(Name = "Valor Viaje")]
        public decimal? ValorViaje { get; set; }

        [Required(ErrorMessage = "Debe ingresar el porcentaje de conductor")]
        [Display(Name = "Ganancia Cdt.")]
        public decimal? PorcentajeConductor { get; set; }

        [Required(ErrorMessage = "Debe ingresar viatico")]
        [Display(Name = "Viatico Transferido")]
        public decimal ViaticoTransferido { get; set; }

        [Required(ErrorMessage = "Debe ingresar viatico gastado")]
        [Display(Name = "Viatico Gastado")]
        public decimal ViaticoGastado { get; set; }
        [Display(Name = "Observaciones")]
        public string? Observacion { get; set; }

    }

}

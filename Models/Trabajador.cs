using System.ComponentModel;

namespace TransportesMR.Models
{
    public class Trabajador
    {
        [Key]
        public int IdTrabajador { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Apellido Paterno")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Apellido Materno")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Rut")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el Sexo")]
        public int? Sexo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Nacimiento")]        
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el Estado Civil")]
        [Display(Name = "Estado Civil")]
        public int? EstadoCivil { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Comuna")]
        public string Comuna { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Dirección")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Teléfono")]
        [Display(Name = "Teléfono")]
        public int? Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Teléfono de Emergencia")]
        [Display(Name = "Teléfono de Emergencia")]
        public int? TelefonoEmergencia { get; set; }


        [Required(ErrorMessage = "Debe ingresar la Licencia de Conducir")]
        [Display(Name = "Tipo de Licencia de Conducir")]
        public string LicenciaConducirTipo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Vencimiento")]
        [Display(Name = "Vencimiento de Licencia de Conducir")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? LicenciaConducirVencimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Código de Barras")]
        [Display(Name = "Código de Barra de Licencia de Conducir")]
        public string LicenciaConducirCodigoBarra { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Inicio de Contrato")]
        [Display(Name = "Fecha de Inicio de Contrato")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? ContratoInicio { get; set; }

        //[Required(ErrorMessage = "Debe ingresar la Fecha de Fin de Contrato")]
        [Display(Name = "Fecha de Fin de Contrato")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime? ContratoFin { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Sueldo Base")]
        [Display(Name = "Sueldo Base")]
        public int? SueldoBase { get; set; }
                
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int? Estado { get; set; }

    }
}

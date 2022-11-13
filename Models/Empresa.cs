namespace TransportesMR.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Rut")]
        public string Rut  { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Razón Social")]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Giro")]
        public string Giro { get; set; }

        [Required(ErrorMessage = "Debe ingresar los Nombres")]
        [Display(Name = "Nombres Encargado")]
        public string NombresEncargado{ get; set; }

        [Required(ErrorMessage = "Debe ingresar los Apellidos")]
        [Display(Name = "Apellidos Encargado")]
        public string ApellidosEncargado { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Teléfono")]
        [Display(Name = "Teléfono Encargado")]
        public int? TelefonoEncargado { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Email")]
        [EmailAddress(ErrorMessage = "Correo ingresado no válido")]
        [Display(Name = "Email de Contacto")]
        public string EmailContacto { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Dirección")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
    }
}

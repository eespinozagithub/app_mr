using Microsoft.AspNetCore.Identity;

namespace TransportesMR.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }


    }
}

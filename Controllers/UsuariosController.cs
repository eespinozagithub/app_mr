using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class UsuariosController : Controller
    {
        //private ApplicationUser _userManager;
        public readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public UsuariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;           
            return View(users);
        }
    }
}

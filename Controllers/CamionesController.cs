using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class CamionesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CamionesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Camion> ListaCamiones = _context.Camiones.ToList();
            return View(ListaCamiones);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CamionMarcaVM Camiones = new CamionMarcaVM();
            Camiones.ListaMarca = _context.MarcaVehiculo.Select(i => new SelectListItem
            {
                Text = i.Marca,
                Value = i.IdMarca.ToString()
            });

            return View(Camiones);

        }
    }
}

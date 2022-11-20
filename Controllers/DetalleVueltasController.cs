using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class DetalleVueltasController : Controller
    {
        public readonly ApplicationDbContext _context;

        public DetalleVueltasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ListadoVueltas()
        {
            List<Vueltas> ListaVueltas = _context.Vueltas.Include(c => c.Camion).ToList();
            return View(ListaVueltas);
        }
        public IActionResult CrearVuelta()
        {
            ViewBag.Combustible = _context.Camion.ToList();
            return View();
        }
    }
}

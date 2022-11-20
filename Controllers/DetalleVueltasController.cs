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
            ViewBag.Camion = _context.Camion.ToList();
            ViewBag.Remolque = _context.Remolque.ToList();
            ViewBag.Trabajador = _context.Trabajador.ToList();
            ViewBag.Empresa = _context.Empresa.ToList();
            ViewBag.Ciudad = _context.Ciudades.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearVuelta(Vueltas cargaVueltas)
        {
            ViewBag.Camion = _context.Camion.ToList();
            ViewBag.Remolque = _context.Remolque.ToList();
            ViewBag.Trabajador = _context.Trabajador.ToList();
            ViewBag.Empresa = _context.Empresa.ToList();
            ViewBag.Ciudad = _context.Ciudades.ToList();
            if (ModelState.IsValid)
            {
                _context.Vueltas.Add(cargaVueltas);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoVueltas));
            }
            return View(cargaVueltas);
        }

        [HttpGet]
        public IActionResult ModificarVuelta(int? id)
        {
            ViewBag.Camion = _context.Camion.ToList();
            ViewBag.Remolque = _context.Remolque.ToList();
            ViewBag.Trabajador = _context.Trabajador.ToList();
            ViewBag.Empresa = _context.Empresa.ToList();
            ViewBag.Ciudad = _context.Ciudades.ToList();
            if (id == null)
            {
                return View();
            }

            var vuelta = _context.Vueltas.FirstOrDefault(c => c.IdVueltas == id);
            return View(vuelta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarVuelta(Vueltas cargaVueltas)
        {
            ViewBag.Camion = _context.Camion.ToList();
            ViewBag.Remolque = _context.Remolque.ToList();
            ViewBag.Trabajador = _context.Trabajador.ToList();
            ViewBag.Empresa = _context.Empresa.ToList();
            ViewBag.Ciudad = _context.Ciudades.ToList();
            if (ModelState.IsValid)
            {
                _context.Vueltas.Update(cargaVueltas);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoVueltas));
            }
            return View(cargaVueltas);
        }
        public IActionResult BorrarVuelta(int? id)
        {
            var IdVuelta = _context.Vueltas.FirstOrDefault(c => c.IdVueltas == id);
            _context.Vueltas.Remove(IdVuelta);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListadoVueltas));
        }
    }
}

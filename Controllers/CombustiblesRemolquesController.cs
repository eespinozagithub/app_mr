using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class CombustiblesRemolquesController : Controller
    {

        public readonly ApplicationDbContext _context;

        public CombustiblesRemolquesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CargaCombustibleRemolque> ListaCarga = _context.CargaCombustibleRemolque.Include(c => c.Remolque).ToList();
            return View(ListaCarga);
        }
        public IActionResult CrearCargaCombustibleRemolque()
        {
            ViewBag.Combustible = _context.Remolque.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCargaCombustibleRemolque(CargaCombustible cargaCombustible)
        {
            ViewBag.Combustible = _context.Remolque.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustible.Add(cargaCombustible);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaCombustible);
        }
        
        [HttpGet]
        public IActionResult ModificarCargaCombustibleRemolque(int? id)
        {
            ViewBag.Combustible = _context.Remolque.ToList();
            if (id == null)
            {
                return View();
            }

            var modeloRemolque = _context.CargaCombustible.FirstOrDefault(c => c.IdCargaCombustible == id);
            return View(modeloRemolque);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCargaCombustibleRemolque(CargaCombustible cargaCombustible)
        {
            ViewBag.Marcas = _context.Remolque.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustible.Update(cargaCombustible);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaCombustible);
        }
        public IActionResult BorrarCargaCombustibleRemolque(int? id)
        {
            var IdCarga = _context.CargaCombustible.FirstOrDefault(c => c.IdCargaCombustible == id);
            _context.CargaCombustible.Remove(IdCarga);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

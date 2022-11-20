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
        public IActionResult CrearCargaCombustibleRemolque(CargaCombustibleRemolque cargaCombustible)
        {
            ViewBag.Combustible = _context.Remolque.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustibleRemolque.Add(cargaCombustible);
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

            var cargaCombustibleRemolque = _context.CargaCombustibleRemolque.FirstOrDefault(c => c.IdCargaCombustibleRemolque == id);
            return View(cargaCombustibleRemolque);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCargaCombustibleRemolque(CargaCombustibleRemolque cargaCombustibleRemolque)
        {
            ViewBag.Marcas = _context.Remolque.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustibleRemolque.Update(cargaCombustibleRemolque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaCombustibleRemolque);
        }
        public IActionResult BorrarCargaCombustibleRemolque(int? id)
        {
            var IdCarga = _context.CargaCombustibleRemolque.FirstOrDefault(c => c.IdCargaCombustibleRemolque == id);
            _context.CargaCombustibleRemolque.Remove(IdCarga);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

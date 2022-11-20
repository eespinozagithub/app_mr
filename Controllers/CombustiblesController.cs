using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class CombustiblesController : Controller
    {

        public readonly ApplicationDbContext _context;

        public CombustiblesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<CargaCombustible> ListaCarga = _context.CargaCombustible.Include(c => c.Camion).ThenInclude(x => x.IdCamion).Where(c => c.Camion.Estado == 1).ToList();
            //List<CargaCombustible> ListaCarga = _context.CargaCombustible.Include(c => c.Camion).ThenInclude(x => x.Patente).ToList();
            List<CargaCombustible> ListaCarga = _context.CargaCombustible.Include(c => c.Camion).ToList();
            return View(ListaCarga);
        }
        public IActionResult CrearCargaCombustible()
        {
            ViewBag.Combustible = _context.Camion.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCargaCombustible(CargaCombustible cargaCombustible)
        {
            ViewBag.Combustible = _context.Camion.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustible.Add(cargaCombustible);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaCombustible);
        }
        
        [HttpGet]
        public IActionResult ModificarCargaCombustible(int? id)
        {
            ViewBag.Combustible = _context.Camion.ToList();
            if (id == null)
            {
                return View();
            }

            var modeloRemolque = _context.CargaCombustible.FirstOrDefault(c => c.IdCargaCombustible == id);
            return View(modeloRemolque);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCargaCombustible(CargaCombustible cargaCombustible)
        {
            ViewBag.Marcas = _context.MarcaRemolque.ToList();
            if (ModelState.IsValid)
            {
                _context.CargaCombustible.Update(cargaCombustible);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaCombustible);
        }
        public IActionResult BorrarCargaCombustible(int? id)
        {
            var IdCarga = _context.CargaCombustible.FirstOrDefault(c => c.IdCargaCombustible == id);
            _context.CargaCombustible.Remove(IdCarga);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class TrabajadoresController : Controller
    {
        public readonly ApplicationDbContext _context;

        public TrabajadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Trabajador> listaTrabajador = _context.Trabajador.OrderByDescending(x => x.Estado).ToList();
            return View(listaTrabajador);
        }

        [HttpGet]
        public IActionResult CrearTrabajador()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTrabajador(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Trabajador.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(trabajador);
        }

        [HttpGet]
        public IActionResult ModificarTrabajador(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }

            var trabajador = _context.Trabajador.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }
            
            return View(trabajador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarTrabajador(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Update(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(trabajador);
        }

        //[HttpGet]
        //public IActionResult getBorrarTrabajador(int? id)
        //{
        //    var trabajador = _context.Trabajador.FirstOrDefault(c => c.IdTrabajador == id);
        //    if (trabajador != null)
        //    {
        //        _context.Trabajador.Remove(trabajador);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }                
        //}
    }
}

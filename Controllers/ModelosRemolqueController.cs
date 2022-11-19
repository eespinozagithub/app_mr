using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;
using TransportesMR.Models;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class ModelosRemolqueController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ModelosRemolqueController(ApplicationDbContext context)
        {            
            _context = context;
        }

        public IActionResult ListadoModeloRemolque()
        {
            List<ModeloRemolque> listaModeloRemolque = _context.ModeloRemolque.OrderByDescending(x => x.IdModelo).Include(c => c.MarcaRemolque).ToList();            
            return View(listaModeloRemolque);
        }

        [HttpGet]
        public IActionResult CrearModeloRemolque()
        {
            ViewBag.Marcas = _context.MarcaRemolque.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearModeloRemolque(ModeloRemolque modeloRemolque)
        {
            ViewBag.Marcas = _context.MarcaRemolque.ToList();

            if (ModelState.IsValid)
            {                
                _context.ModeloRemolque.Add(modeloRemolque);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoModeloRemolque));
            }
            return View(modeloRemolque);
        }

        [HttpGet]

        public IActionResult ModificarModeloRemolque(int? id)
        {
            ViewBag.Marcas = _context.MarcaRemolque.ToList();
            if (id == null)
            {
                return View();
            }

            var modeloRemolque = _context.ModeloRemolque.FirstOrDefault(c => c.IdModelo == id);
            return View(modeloRemolque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarModeloRemolque(ModeloRemolque modeloRemolque)
        {
            ViewBag.Marcas = _context.MarcaRemolque.ToList();
            if (ModelState.IsValid)
            {
                _context.ModeloRemolque.Update(modeloRemolque);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoModeloRemolque));
            }
            return View(modeloRemolque);
        }
    }
}

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
        private List<MarcaRemolque> lstMarcas;

        public ModelosRemolqueController(ApplicationDbContext context)
        {            
            _context = context;
            lstMarcas = _context.MarcaRemolque.Where(x => x.Estado == true).ToList();
        }

        public IActionResult ListadoModeloRemolque()
        {
            List<ModeloRemolque> listaModeloRemolque = _context.ModeloRemolque.OrderByDescending(x => x.Estado).Include(c => c.MarcaRemolque).ToList();            
            return View(listaModeloRemolque);
        }

        [HttpGet]
        public IActionResult CrearModeloRemolque()
        {
            ViewBag.Marcas = lstMarcas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearModeloRemolque(ModeloRemolque modeloRemolque)
        {
            ViewBag.Marcas = lstMarcas;

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
            ViewBag.Marcas = lstMarcas;
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
            ViewBag.Marcas = lstMarcas;
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

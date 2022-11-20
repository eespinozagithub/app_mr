using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class RemolquesController : Controller
    {
        public readonly ApplicationDbContext _context;
        private List<MarcaRemolque> lstMarcas;

        public RemolquesController(ApplicationDbContext context)
        {
            _context = context;
            lstMarcas = _context.MarcaRemolque.Where(x => x.Estado == true).ToList();
        }

        public IActionResult ListadoRemolque()
        {
            List<Remolque> listaRemolque = _context.Remolque.OrderByDescending(x => x.Estado).Include(x => x.ModeloRemolque).ThenInclude(x => x.MarcaRemolque).ToList();
            return View(listaRemolque);
        }

        [HttpGet]
        public IActionResult CrearRemolque()
        {
            ViewBag.Marcas = lstMarcas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRemolque(Remolque remolque)
        {
            ViewBag.Marcas = lstMarcas;
            if (ModelState.IsValid)
            {
                _context.Remolque.Add(remolque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoRemolque));

            }
            return View(remolque);
        }

        [HttpGet]
        public IActionResult ModificarRemolque(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            var remolque = _context.Remolque.Find(id);
            if (remolque == null)
            {
                return NotFound();
            }

            var idMarcaSel = _context.ModeloRemolque.FirstOrDefault(c => c.IdModelo == remolque.IdModelo).IdMarca;
            ViewBag.Marcas = lstMarcas;
            ViewBag.Modelos = _context.ModeloRemolque.ToList().Where(p => p.IdMarca == idMarcaSel);
            ViewBag.idMarcaSeleccionada = idMarcaSel;

            return View(remolque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarRemolque(Remolque remolque)
        {
            if (ModelState.IsValid)
            {
                _context.Update(remolque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoRemolque));
            }

            ViewBag.Marcas = lstMarcas;            
            if( remolque.IdModelo != null)
            {
                var idMarcaSel = _context.ModeloRemolque.FirstOrDefault(c => c.IdModelo == remolque.IdModelo).IdMarca;
                ViewBag.Modelos = _context.ModeloRemolque.ToList().Where(p => p.IdMarca == idMarcaSel);
                ViewBag.idMarcaSeleccionada = idMarcaSel;
            }
            else
            {
                ViewBag.Modelos = _context.ModeloRemolque.ToList().Where(p => p.IdMarca == 0);
                ViewBag.idMarcaSeleccionada = null;
            }

            return View(remolque);
        }

        [HttpPost]
        public JsonResult getModelos(int IdMarca)
        {
            var modelos = _context.ModeloRemolque.ToList().Where(p => p.IdMarca == IdMarca);
            return Json(new SelectList(modelos, "IdModelo", "Modelo"));
        }
    }
}

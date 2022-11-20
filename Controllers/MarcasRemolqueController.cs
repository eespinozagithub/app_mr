using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class MarcasRemolqueController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MarcasRemolqueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListadoMarcaRemolque()
        {
            List<MarcaRemolque> listaMarcaRemolque= _context.MarcaRemolque.OrderByDescending(x => x.Estado).ToList();
            return View(listaMarcaRemolque);
        }

        [HttpGet]
        public IActionResult CrearMarcaRemolque()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMarcaRemolque(MarcaRemolque marcaRemolque)
        {
            if (ModelState.IsValid)
            {
                _context.MarcaRemolque.Add(marcaRemolque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoMarcaRemolque));

            }
            return View(marcaRemolque);
        }

        [HttpGet]
        public IActionResult ModificarMarcaRemolque(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaRemolque = _context.MarcaRemolque.Find(id);
            if (marcaRemolque == null)
            {
                return NotFound();
            }

            return View(marcaRemolque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarMarcaRemolque(MarcaRemolque marcaRemolque)
        {
            if (ModelState.IsValid)
            {
                _context.Update(marcaRemolque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoMarcaRemolque));

            }
            return View(marcaRemolque);
        }
    }
}

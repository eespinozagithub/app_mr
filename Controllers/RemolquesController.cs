using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class RemolquesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public RemolquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListadoRemolque()
        {
            List<Remolque> listaRemolque = _context.Remolque.OrderByDescending(x => x.IdRemolque).ToList();
            return View(listaRemolque);
        }

        [HttpGet]
        public IActionResult CrearRemolque()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRemolque(Remolque remolque)
        {
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
            return View(remolque);
        }
    }
}

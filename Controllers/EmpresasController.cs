using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class EmpresasController : Controller
    {

        public readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Empresa> listaEmpresa = _context.Empresa.OrderBy(x => x.IdEmpresa).ToList();
            return View(listaEmpresa);
        }

        [HttpGet]
        public IActionResult CrearEmpresa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEmpresa(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Empresa.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(empresa);
        }

        [HttpGet]
        public IActionResult ModificarEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _context.Empresa.Find(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarEmpresa(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(empresa);
        }
    }
}

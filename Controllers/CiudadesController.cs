using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class CiudadesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CiudadesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ListadoCiudades()
        {
            List<Ciudades> ListaCiudades = _context.Ciudades.OrderByDescending(x => x.Estado).ToList();
            return View(ListaCiudades);
        }

        [HttpGet]
        public IActionResult CrearCiudad()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCiudad(Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                _context.Ciudades.Add(ciudades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoCiudades));

            }
            return View(ciudades);
        }
        [HttpGet]
        public IActionResult ModificarCiudad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = _context.Ciudades.Find(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarCiudad(Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ciudades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoCiudades));


            }
            return View(ciudades);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;
using TransportesMR.Models;

namespace TransportesMR.Controllers
{
    public class MarcasVehiculosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MarcasVehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListadoMarcaVehiculo()
        {
            List<MarcaVehiculo> ListaMarcaVehiculo = _context.MarcaVehiculo.OrderByDescending(x => x.Estado).ToList();
            return View(ListaMarcaVehiculo);
        }

        [HttpGet]
        public IActionResult CrearMarcaVehiculo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMarcaVehiculo(MarcaVehiculo marcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.MarcaVehiculo.Add(marcaVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoMarcaVehiculo));

            }
            return View(marcaVehiculo);
        }


        [HttpGet]
        public IActionResult ModificarMarcaVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaVehiculo = _context.MarcaVehiculo.Find(id);
            if (marcaVehiculo == null)
            {
                return NotFound();
            }

            return View(marcaVehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarMarcaVehiculo(MarcaVehiculo marcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(marcaVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoMarcaVehiculo));


            }
            return View(marcaVehiculo);
        }
        
    }
}

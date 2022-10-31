using Microsoft.AspNetCore.Mvc;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class MarcasVehiculosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MarcasVehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<MarcaVehiculo> ListaMarcaVehiculo = _context.MarcaVehiculo.ToList();
            return View(ListaMarcaVehiculo);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setCrear(MarcaVehiculo marcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.MarcaVehiculo.Add(marcaVehiculo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var marcaVehiculo = _context.MarcaVehiculo.FirstOrDefault(c => c.IdMarca == id);
            return View(marcaVehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditar(MarcaVehiculo marcaVeh)
        {
            if (ModelState.IsValid)
            {
                _context.MarcaVehiculo.Update(marcaVeh);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaVeh);
        }

        [HttpGet]
        public IActionResult getBorrar(int? id)
        {
            var marcaVehiculo = _context.MarcaVehiculo.FirstOrDefault(c => c.IdMarca == id);
            _context.MarcaVehiculo.Remove(marcaVehiculo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

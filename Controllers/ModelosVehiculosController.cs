using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportesMR.Data;
using TransportesMR.Models;
using TransportesMR.ViewModels;


namespace TransportesMR.Controllers
{
    public class ModelosVehiculosController : Controller
    {
        public readonly ApplicationDbContext _context;
        private List<MarcaVehiculo> lstMarcas;

        public ModelosVehiculosController(ApplicationDbContext context)
        {
            _context = context;
            lstMarcas = _context.MarcaVehiculo.Where(x => x.Estado == true).ToList();
        }
        public IActionResult ListadoModeloVehiculo()
        {
            List<ModeloVehiculo> ListaModelosVehiculo = _context.ModeloVehiculo.OrderByDescending(x => x.Estado).Include(c => c.MarcaVehiculo).ToList();
            return View(ListaModelosVehiculo);
        }

        [HttpGet]
        public IActionResult CrearModeloVehiculo()
        {
            ViewBag.Marcas = lstMarcas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearModeloVehiculo(ModeloVehiculo modeloVehiculo)
        {
            ViewBag.Marcas = lstMarcas;

            if (ModelState.IsValid)
            {
                _context.ModeloVehiculo.Add(modeloVehiculo);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoModeloVehiculo));
            }
            return View(modeloVehiculo);
        }

        [HttpGet]
        public IActionResult ModificarModeloVehiculo(int? id)
        {
            ViewBag.Marcas = lstMarcas;
            if (id == null)
            {
                return View();
            }

            var modeloVehiculo = _context.ModeloVehiculo.FirstOrDefault(c => c.IdModelo == id);
            return View(modeloVehiculo);
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarModeloVehiculo(ModeloVehiculo modeloVehiculo)
        {
            ViewBag.Marcas = lstMarcas;
            if (ModelState.IsValid)
            {
                _context.ModeloVehiculo.Update(modeloVehiculo);
                _context.SaveChanges();
                return RedirectToAction(nameof(ListadoModeloVehiculo));
            }
            return View(modeloVehiculo);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportesMR.Data;
using TransportesMR.ViewModels;


namespace TransportesMR.Controllers
{
    public class ModelosVehiculosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ModelosVehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ModeloVehiculo> ListaModelosVehiculo = _context.ModeloVehiculo.Include(c => c.MarcaVehiculo).ToList();
            return View(ListaModelosVehiculo);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            MarcaModeloVM marcaModelo = new MarcaModeloVM();
            marcaModelo.ListaMarca = _context.MarcaVehiculo.Select(i => new SelectListItem
            {
                Text = i.Marca,
                Value = i.IdMarca.ToString()
            });

            return View(marcaModelo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setCrear(ModeloVehiculo modeloVehiculo)
        {

            if (ModelState.IsValid)
            {
                _context.ModeloVehiculo.Add(modeloVehiculo);
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

            var modeloVehiculo = _context.ModeloVehiculo.FirstOrDefault(c => c.IdModelo == id);
            return View(modeloVehiculo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setEditar(ModeloVehiculo modeloVeh)
        {
            if (ModelState.IsValid)
            {
                _context.ModeloVehiculo.Update(modeloVeh);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloVeh);
        }

        [HttpGet]
        public IActionResult getBorrar(int? id)
        {
            var modeloVehiculo = _context.ModeloVehiculo.FirstOrDefault(c => c.IdModelo == id);
            _context.ModeloVehiculo.Remove(modeloVehiculo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

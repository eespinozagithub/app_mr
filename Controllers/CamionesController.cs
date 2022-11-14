using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using TransportesMR.Data;
using TransportesMR.Models;
using TransportesMR.ViewModels;

namespace TransportesMR.Controllers
{
    public class CamionesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CamionesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Camion> ListaCamiones = _context.Camiones.Include(c=> c.ModeloVehiculo).ThenInclude(x => x.MarcaVehiculo).Where(c=> c.Estado == true).ToList();
            return View(ListaCamiones);
        }

        [HttpGet]
        public IActionResult CrearCamion()
        {
            CamionMarcaVM Camiones = new CamionMarcaVM();
            Camiones.ListaMarca = _context.MarcaVehiculo.Select(i => new SelectListItem
            {
                Text = i.Marca,
                Value = i.IdMarca.ToString()
            });

            return View(Camiones);

        }

        [HttpPost]
        public JsonResult getModelos(int IdMarca)
        {
            var modelos = _context.ModeloVehiculo.ToList().Where(p => p.IdMarca == IdMarca);
            return Json(new SelectList(modelos, "IdModelo", "Modelo"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult setCrearCamion(Camion camion)
        {
            camion.Estado = true;
            if (ModelState.IsValid)
            {

                _context.Camiones.Add(camion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]

        public IActionResult EditarCamion(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var camiones = _context.Camiones.FirstOrDefault(c => c.IdVehiculo == id);
            return View(camiones);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCamion(Camion camion)
        {
            if (ModelState.IsValid)
            {
                _context.Camiones.Update(camion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(camion);
        }

    }
    
}

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
        private List<MarcaVehiculo> lstMarcas;

        public CamionesController(ApplicationDbContext context)
        {
            _context = context;
            lstMarcas = _context.MarcaVehiculo.Where(x => x.Estado == true).ToList();
        }

        public IActionResult ListadoCamion()
        {
            List<Camion> ListaCamiones = _context.Camion.OrderByDescending(x => x.Estado).Include(x => x.ModeloVehiculo).ThenInclude(x => x.MarcaVehiculo).ToList();
            return View(ListaCamiones);
        }

        [HttpGet]
        public IActionResult CrearCamion()
        {
            ViewBag.Marcas = lstMarcas;
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCamion(Camion camion)
        {
            ViewBag.Marcas = lstMarcas;
            if (ModelState.IsValid)
            {
                _context.Camion.Add(camion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoCamion));

            }
            return View(camion);
        }

        [HttpGet]
        public IActionResult ModificarCamion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camion = _context.Camion.Find(id);
            if (camion == null)
            {
                return NotFound();
            }

            var idMarcaSel = _context.ModeloVehiculo.FirstOrDefault(c => c.IdModelo == camion.IdModelo).IdMarca;
            ViewBag.Marcas = lstMarcas;
            ViewBag.Modelos = _context.ModeloVehiculo.ToList().Where(p => p.IdMarca == idMarcaSel);
            ViewBag.idMarcaSeleccionada = idMarcaSel;

            return View(camion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarCamion(Camion camion)
        {
            if (ModelState.IsValid)
            {
                _context.Update(camion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoCamion));
            }

            ViewBag.Marcas = lstMarcas;
            if (camion.IdModelo != null)
            {
                var idMarcaSel = _context.ModeloVehiculo.FirstOrDefault(c => c.IdModelo == camion.IdModelo).IdMarca;
                ViewBag.Modelos = _context.ModeloVehiculo.ToList().Where(p => p.IdMarca == idMarcaSel);
                ViewBag.idMarcaSeleccionada = idMarcaSel;
            }
            else
            {
                ViewBag.Modelos = _context.ModeloVehiculo.ToList().Where(p => p.IdMarca == 0);
                ViewBag.idMarcaSeleccionada = null;
            }

            return View(camion);
        }

        [HttpPost]
        public JsonResult getModelos(int IdMarca)
        {
            var modelos = _context.ModeloVehiculo.ToList().Where(p => p.IdMarca == IdMarca);
            return Json(new SelectList(modelos, "IdModelo", "Modelo"));
        }

        //[HttpPost]
        //public JsonResult TraeMarcas()
        //{
        //    var marcas = _context.MarcaVehiculo.ToList();
        //    return Json(new SelectList(marcas, "IdMarca", "Marca"));
        //}
    }
}

using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TransportesMR.Data;

namespace TransportesMR.Controllers
{
    public class ReportesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {            
            _context = context;
        }

        [HttpGet]
        public IActionResult DetalleVuelta()
        {
            
            ViewBag.Camion = _context.Camion.Where(x => x.Estado == 1).ToList();
            ViewBag.Trabajador = _context.Trabajador.Where(x => x.Estado == 1)
                .Select(x => new { x.IdTrabajador, Nombre =  x.Nombre + " " + x.ApellidoPaterno })
                .ToList();
            ViewBag.Empresa = _context.Empresa.ToList();

            return View();
        }
        [HttpPost]
        public FileResult DetalleVueltaExcel()
        //public void DetalleVuelta(Empresa empresa)
        {
            //FILTRO CON DATOS
            var fecha = DateTime.Today;
            var nombreArchivo = $"DetalleVuelta - {fecha.ToString("dd_MM_yyyy")}.xlsx";

            List<Camion> lstCamiones = _context.Camion.Where(x => x.Estado == 1).ToList();

            System.Data.DataTable dtExportar = new System.Data.DataTable("Reporte");

            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";            
            dtExportar.Columns.Add(column);

            foreach (var result in lstCamiones)
            {
                dtExportar.Rows.Add(result.IdCamion);
            }

            return ExportarExcel(nombreArchivo, dtExportar);
        }
        private FileResult ExportarExcel(string nombreArchivo, System.Data.DataTable dtDatos)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtDatos);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nombreArchivo);
                }
            }
        }

        public IActionResult RendimientoCamiones()
        {
            return View();
        }

        public IActionResult CalculoSueldos()
        {
            return View();
        }

        public IActionResult UtilidadEmpresa()
        {
            return View();
        }


    }
}

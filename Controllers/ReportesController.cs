using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Dynamic;
using TransportesMR.Data;
using TransportesMR.ViewReports;

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
            ViewBag.Camiones = _context.Camion.Where(x => x.Estado == 1).ToList();
            ViewBag.Trabajador = _context.Trabajador.Where(x => x.Estado == 1)
                .Select(x => new { x.IdTrabajador, Nombre = x.Nombre + " " + x.ApellidoPaterno })
                .ToList();
            ViewBag.Empresa = _context.Empresa.ToList();
            ViewBag.Meses = new List<Object>
            {
                new { id = 1, value = "Enero" },
                new { id = 2, value = "Febrero" },
                new { id = 3, value = "Marzo" },
                new { id = 4, value = "Abril" },
                new { id = 5, value = "Mayo" },
                new { id = 6, value = "Junio" },
                new { id = 7, value = "Julio" },
                new { id = 8, value = "Agosto" },
                new { id = 9, value = "Septiembre" },
                new { id = 10, value = "Octubre" },
                new { id = 11, value = "Noviembre" },
                new { id = 12, value = "Diciembre" }
            };
            ViewBag.Years = _context.Vueltas
                .ToList()
                .DistinctBy((x) => x.FechaSalida!.Value.Year)
                .Select(x => new
                {
                    id = x.FechaSalida!.Value.Year,
                    value = x.FechaSalida!.Value.Year
                })
                .OrderByDescending(x => x.id);

            return View();
        }

        [HttpPost]
        public FileResult DetalleCamionesExcel()
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
        private List<DetalleVuelta> GetDetalleVuelta(int year, int month, int idCamion) // muestra info en pantalla
        {
            return _context.DetalleVueltas
                .FromSqlInterpolated($"call `GetDetalleVueltas`({year},{month},{idCamion})")
                .ToList();
        }

        [HttpPost]
        public FileResult DetalleVueltaExcel(DetalleVueltaFilters filters) //exporta excel reporte detalle vueltas
        {
            //FILTRO CON DATOS
            var fecha = DateTime.Today;
            var nombreArchivo = $"DetalleVuelta - {fecha.ToString("dd_MM_yyyy")}.xlsx";


            List<DetalleVuelta> listVueltas = GetDetalleVuelta(filters.YearDV, filters.MonthDV, filters.IdCamionDV);;

            var dtExportar = new DataTable("Reporte");
            dtExportar.Columns.Add(new DataColumn("Id Vuelta", Type.GetType("System.Int32")!));
            dtExportar.Columns.Add(new DataColumn("Id Camion", Type.GetType("System.Int32")!));
            dtExportar.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")!));
            dtExportar.Columns.Add(new DataColumn("Apellido Paterno", Type.GetType("System.String")!));
            dtExportar.Columns.Add(new DataColumn("Apellido Materno", Type.GetType("System.String")!));

            foreach (var vuelta in listVueltas)
                dtExportar.Rows.Add(
                    vuelta.IdVueltas,
                    vuelta.IdCamion,
                    vuelta.Nombre,
                    vuelta.ApellidoPaterno,
                    vuelta.ApellidoMaterno);

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

using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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

        private List<DetalleSueldo> GetDetalleSueldo(int year, int month, int IdTrabajador) // muestra info en pantalla
        {
            return _context.DetalleSueldos
                .FromSqlInterpolated($"call `usp_getReporteSueldos`({IdTrabajador},{month},{year})")
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
            ViewBag.Camiones = _context.Camion.Where(x => x.Estado == 1).ToList();
            ViewBag.Trabajador = _context.Trabajador.Where(x => x.Estado == 1)
                .Select(x => new { x.IdTrabajador, Nombre = x.Nombre + " " + x.ApellidoPaterno })
                .ToList();

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
        public FileResult DetalleSueldosExcel(DetalleSueldoFilters filters) //exporta excel reporte detalle vueltas
        {
            //FILTRO CON DATOS
            var fecha = DateTime.Now;
            var nombreArchivo = $"DetalleSueldos - {fecha.ToString("dd_MM_yyyy_HHmm")}.xlsx";


            List<DetalleSueldo> listSueldos = GetDetalleSueldo(filters.YearDV, filters.MonthDV, filters.IdTrabajador); ;

            var dtExportar = new DataTable("Reporte");
            dtExportar.Columns.Add(new DataColumn("Id Trabajador", Type.GetType("System.Int32")!));
            dtExportar.Columns.Add(new DataColumn("Nombre Trabajador", Type.GetType("System.String")!));
            dtExportar.Columns.Add(new DataColumn("Sueldo", Type.GetType("System.Int32")!));

            foreach (var sueldo in listSueldos)
                dtExportar.Rows.Add(
                    sueldo.IdTrabajador,
                    sueldo.Nombre_Trabajador,
                    sueldo.Sueldo);

            return ExportarExcel(nombreArchivo, dtExportar);
        }


        [HttpPost]
        //public IActionResult getRPTSueldos(int YearDV, int MonthDV, int IdTrabajador)
        public IActionResult getRPTSueldos(IFormCollection formcollection)
        {
            try
            {

                int YearDV = Convert.ToInt32(formcollection["YearDV"]);
                int MonthDV = Convert.ToInt32(formcollection["MonthDV"]);
                int IdTrabajador = Convert.ToInt32(formcollection["IdTrabajador"]);

                var detalleSueldos = GetDetalleSueldo(YearDV, MonthDV, IdTrabajador);

                return Json(new { detalleSueldos });

            }
            catch (Exception)
            {
                throw;
            }

        }

        

        public IActionResult LoadDT_SP()
        {
            try
            {
                int YearDV = 2023;
                int MonthDV = 1;
                int IdTrabajador = 0;
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = GetDetalleSueldo(YearDV, MonthDV, IdTrabajador);
                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, Data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        


        public IActionResult UtilidadEmpresa()
        {
            return View();
        }


    }
}

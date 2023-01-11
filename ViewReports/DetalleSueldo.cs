namespace TransportesMR.ViewReports
{
    public class DetalleSueldo
    {
        [Key]
        public int IdTrabajador { get; set; }
        public string Nombre_Trabajador { get; set; }

        public int Sueldo { get; set; }
    }
}

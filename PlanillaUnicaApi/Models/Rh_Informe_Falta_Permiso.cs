using System.Drawing;

namespace PlanillaUnicaApi.Models
{
    public class Rh_Informe_Falta_Permiso
    {
        public string empleado_id { get; set; } = string.Empty;
        public int contratos { get; set; }
        public string tipo { get; set; } = string.Empty;
        public string fecha_inicio { get; set; } = string.Empty;
        public string fecha_termino { get; set; } = string.Empty;
        public decimal dias { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public string tipo_medio_dia { get; set; } = string.Empty;
        public string envia_email_supervidor { get; set; } = string.Empty;
        public string numero_licencia { get; set; } = string.Empty;
        public string dias_a_pagar { get; set; } = string.Empty;
        public string no_rebaja { get; set; } = string.Empty;
        public string fecha_concepcion { get; set; } = string.Empty;
        public string fecha_aplicacion { get; set; } = string.Empty;
        public string goce_sueldo { get; set; } = string.Empty;
        public string subtipo_ausencia { get; set; } = string.Empty;
        public string medico_tratante { get; set; } = string.Empty;
        public string especialidad { get; set; } = string.Empty;

    }
}

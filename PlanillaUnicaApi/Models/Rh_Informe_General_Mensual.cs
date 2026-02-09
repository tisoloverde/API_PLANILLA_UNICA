namespace PlanillaUnicaApi.Models
{
    public class Rh_Informe_General_Mensual
    {
        public string Empresa { get; set; } = string.Empty;
        public string CECO { get; set; } = string.Empty;
        public string Nombre_CECO { get; set; } = string.Empty;
        public string RUN { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int Contrato { get; set; }
        public string Fecha_Ingreso { get; set; } = string.Empty;
        public string Fecha_Termino { get; set; } = string.Empty;
        public decimal Dias_A_Pagar { get; set; }
        public decimal HE50 { get; set; }
        public decimal HE100 { get; set; }
        public decimal Atraso { get; set; }
        public decimal Licencia { get; set; }
        public decimal Vacaciones { get; set; }
    }
}

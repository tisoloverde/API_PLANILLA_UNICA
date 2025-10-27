namespace PlanillaUnicaApi.Models
{
    public class Rh_Informe_Salida_He
    {
        public string Plantilla { get; set; } = string.Empty;
        public int Contrato { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Origen { get; set; } = string.Empty;
        public string Objeto { get; set; } = string.Empty;
        public string PeriodoDePago { get; set; } = string.Empty;
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaTermino { get; set; } = string.Empty;
        public string Institucion { get; set; } = string.Empty;
        public string DatoAdicional { get; set; } = string.Empty;
        public string Comentario { get; set; } = string.Empty;
        public string ValorDefecto { get; set; } = string.Empty;
        public string CentroCosto { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
    }
}

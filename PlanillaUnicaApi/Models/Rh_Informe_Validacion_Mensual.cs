namespace PlanillaUnicaApi.Models
{
    public class Rh_Informe_Validacion_Mensual
    {
      public decimal IDPERSONAL { get; set; }
        public string RUT { get; set; } = string.Empty;
        public string NOMBRES { get; set; } = string.Empty;
        public string CLASIFICACION { get; set; } = string.Empty;
        public string SIGLA_CLASIFICACION { get; set; } = string.Empty;
        public string FECHA_INGRESO { get; set; } = string.Empty;
        public string FECHA_TERMINO { get; set; } = string.Empty;
        public string CECO { get; set; } = string.Empty;
        public string NOMENCLATURA { get; set; } = string.Empty;
        public string FECHA_MARCA { get; set; } = string.Empty;
        public string MES { get; set; } = string.Empty;
        public string ANO { get; set; } = string.Empty;
        public string SIGLA { get; set; } = string.Empty;
        public string DESCRIPCION_SIGLA { get; set; } = string.Empty;
        public string CONCEPTO { get; set; } = string.Empty;    
        public string PAGADO_NOPAGADO { get; set; } = string.Empty;
        public string ESTADO { get; set; } = string.Empty;

    }
}

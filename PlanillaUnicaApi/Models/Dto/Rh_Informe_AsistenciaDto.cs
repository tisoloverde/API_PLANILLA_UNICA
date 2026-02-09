namespace PlanillaUnicaApi.Models.Dto
{
    public class Rh_Informe_AsistenciaDto
    {
        public string Email { get; set; } = string.Empty;
        public int CentroCosto { get; set; }
        public string CentroCostoDescripcion { get; set; } = string.Empty;
        public string UsuarioGenera { get; set; } = string.Empty;
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaTermino { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;
        public List<Rh_Tipo_Informe> TiposInforme { get; set; }
    }
}

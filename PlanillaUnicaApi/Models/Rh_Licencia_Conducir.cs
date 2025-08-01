namespace PlanillaUnicaApi.Models
{
	public class Rh_Licencia_Conducir
	{
		public decimal Rhliccon_Id { get; set; }
		public string Rhliccon_Descripcion { get; set; } = string.Empty;
		public string Rhliccon_Tipo { get; set; } = string.Empty;
		public string Rhliccon_Vigencia { get; set; } = string.Empty;
	}
}

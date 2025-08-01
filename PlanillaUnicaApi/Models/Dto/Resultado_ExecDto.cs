namespace PlanillaUnicaApi.Models.Dto
{
	public class Resultado_ExecDto
	{
		public decimal Id { get; set; }
		public int Cantidad { get; set; }
		public int Status { get; set; }
		public string Estado { get; set; }
		public string? Mensaje { get; set; }
	}
}

using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Models.Dto;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioDotacion
	{
		public List<DotacionLista> ObtieneDotacionLista(decimal centroCosto, decimal periodo);
		public Resultado_ExecDto CreateDotacion(Rh_Dotacion dotacion);
		public Resultado_ExecDto ActualizaDotacion(Rh_Dotacion dotacion);
	}
}

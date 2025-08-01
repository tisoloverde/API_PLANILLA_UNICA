using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioSituacion
	{
		public List<Rh_Situacion> GetAllSituacion();
	}
}

using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioSalud
	{
		public List<Rh_Salud> GetAllSalud();
	}
}

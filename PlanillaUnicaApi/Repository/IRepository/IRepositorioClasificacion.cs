using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioClasificacion
	{
		public List<Rh_Clasificacion> GetAllClasificacion();
	}
}

using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioCargoGenerico
	{
		public List<Rh_Cargo_Generico> GetAllCargoGenerico();
	}
}

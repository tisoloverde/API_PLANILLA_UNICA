using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioTipoPersonalOfertado
	{
		public List<Rh_Tipo_Personal_Ofertado> GetAllTipoPersonalOfertado();
	}
}

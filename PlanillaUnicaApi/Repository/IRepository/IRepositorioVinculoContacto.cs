using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioVinculoContacto
	{
		public List<Rh_Vinculo_Contacto> GetAllVinculoContacto();
	}
}

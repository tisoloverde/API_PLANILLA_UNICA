using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioLicenciaConducir
	{
		public List<Rh_Licencia_Conducir> GetAllLicenciaConducir();
	}
}

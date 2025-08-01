using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioTipoAbono
	{
		public List<Rh_Tipo_Abono> GetAllTipoAbono();
	}
}

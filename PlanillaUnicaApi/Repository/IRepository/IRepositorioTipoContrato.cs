using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioTipoContrato
	{
		public List<Rh_Tipo_Contrato> GetAllTipoContrato();
	}
}

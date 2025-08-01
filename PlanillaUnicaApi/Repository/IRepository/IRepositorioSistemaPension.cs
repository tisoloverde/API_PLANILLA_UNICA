using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioSistemaPension
	{
		public List<Rh_Sistema_Pension> GetAllSistemaPension();
	}
}

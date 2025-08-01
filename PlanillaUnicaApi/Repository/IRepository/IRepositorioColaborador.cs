using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioColaborador
	{
		public List<ColaboradorLista> ObtieneColaboradorLista();
		public ColaboradorLista ObtieneColaboradorListaId(decimal colaboradorId);
	}
}

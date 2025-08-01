using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioColaborador: IRepositorioColaborador
	{
		private readonly string? connectionString;
		public RepositorioColaborador(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		public List<ColaboradorLista> ObtieneColaboradorLista()
		{
			using (var conexion = new SqlConnection(connectionString))
			{
				var clientes = conexion.Query<ColaboradorLista>(@"
																EXEC SP_RH_OBTIENE_COLABORADORES_LISTA ");

				return clientes.ToList();
			}
		}

		public ColaboradorLista ObtieneColaboradorListaId(decimal colaboradorId)
		{
			string spName = "SP_RH_OBTIENE_COLABORADOR_LISTA_ID";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@RHCOL_ID", colaboradorId);
				var colaboradorLista = conexion.Query<ColaboradorLista>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

				return colaboradorLista.FirstOrDefault();
			}
		}
	}
}

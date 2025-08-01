using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioExpatriado : IRepositorioExpatriado
	{
		private readonly string? connectionString;
		public RepositorioExpatriado(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas tipos de expatriados
		/// </summary>
		public List<Rh_Expatriado> GetAllExpatriado()
		{
			string spName = "SP_RH_OBTIENE_EXPATRIADO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var expatriado = conexion.Query<Rh_Expatriado>(spName, commandType: CommandType.StoredProcedure);

				return expatriado.ToList();
			}
		}
	}
}

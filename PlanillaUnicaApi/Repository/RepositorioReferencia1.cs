using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioReferencia1 : IRepositorioReferencia1
	{
		private readonly string? connectionString;
		public RepositorioReferencia1(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las referencias 1 desde la bd
		/// </summary>
		public List<Rh_Referencia_1> GetAllReferencia1()
		{
			string spName = "SP_RH_OBTIENE_REFERENCIA_1";
			using (var conexion = new SqlConnection(connectionString))
			{

				var referencia1 = conexion.Query<Rh_Referencia_1>(spName, commandType: CommandType.StoredProcedure);

				return referencia1.ToList();
			}
		}
	}
}

using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioReferencia2 : IRepositorioReferencia2
	{
		private readonly string? connectionString;
		public RepositorioReferencia2(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las referencias 2 desde la bd
		/// </summary>
		public List<Rh_Referencia_2> GetAllReferencia2()
		{
			string spName = "SP_RH_OBTIENE_REFERENCIA_2";
			using (var conexion = new SqlConnection(connectionString))
			{

				var referencia2 = conexion.Query<Rh_Referencia_2>(spName, commandType: CommandType.StoredProcedure);

				return referencia2.ToList();
			}
		}
	}
}

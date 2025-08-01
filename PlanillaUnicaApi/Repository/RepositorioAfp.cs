using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioAfp : IRepositorioAfp
	{
		private readonly string? connectionString;
		public RepositorioAfp(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las afp
		/// </summary>
		public List<Rh_Afp> GetAllAfp()
		{
			string spName = "SP_RH_OBTIENE_AFP";
			using (var conexion = new SqlConnection(connectionString))
			{

				var afp = conexion.Query<Rh_Afp>(spName, commandType: CommandType.StoredProcedure);

				return afp.ToList();
			}
		}

	}
}

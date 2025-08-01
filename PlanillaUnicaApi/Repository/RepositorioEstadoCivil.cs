using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioEstadoCivil : IRepositorioEstadoCivil
	{
		private readonly string? connectionString;
		public RepositorioEstadoCivil(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los estados civiles
		/// </summary>
		public List<Rh_Estado_Civil> GetAllEstadoCivil()
		{
			string spName = "SP_RH_OBTIENE_ESTADO_CIVIL";
			using (var conexion = new SqlConnection(connectionString))
			{

				var estadosCivil = conexion.Query<Rh_Estado_Civil>(spName, commandType: CommandType.StoredProcedure);

				return estadosCivil.ToList();
			}
		}
	}
}

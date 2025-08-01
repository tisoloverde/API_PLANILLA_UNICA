using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioSalud : IRepositorioSalud
	{
		private readonly string? connectionString;
		public RepositorioSalud(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las instituciones de salud
		/// </summary>
		public List<Rh_Salud> GetAllSalud()
		{
			string spName = "SP_RH_OBTIENE_SALUD";
			using (var conexion = new SqlConnection(connectionString))
			{

				var salud = conexion.Query<Rh_Salud>(spName, commandType: CommandType.StoredProcedure);

				return salud.ToList();
			}
		}
	}
}

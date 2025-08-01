using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioProfesion : IRepositorioProfesion
	{
		private readonly string? connectionString;
		public RepositorioProfesion(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las profesiones
		/// </summary>
		public List<Rh_Profesion> GetAllProfesion()
		{
			string spName = "SP_RH_OBTIENE_PROFESION";
			using (var conexion = new SqlConnection(connectionString))
			{

				var profesion = conexion.Query<Rh_Profesion>(spName, commandType: CommandType.StoredProcedure);

				return profesion.ToList();
			}
		}
	}
}

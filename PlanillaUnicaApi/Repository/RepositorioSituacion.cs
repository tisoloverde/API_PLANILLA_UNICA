using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioSituacion : IRepositorioSituacion
	{
		private readonly string? connectionString;
		public RepositorioSituacion(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las situaciones
		/// </summary>
		public List<Rh_Situacion> GetAllSituacion()
		{
			string spName = "SP_RH_OBTIENE_SITUACION";
			using (var conexion = new SqlConnection(connectionString))
			{

				var situacion = conexion.Query<Rh_Situacion>(spName, commandType: CommandType.StoredProcedure);

				return situacion.ToList();
			}
		}
	}
}

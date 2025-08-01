using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioClasificacion : IRepositorioClasificacion
	{
		private readonly string? connectionString;
		public RepositorioClasificacion(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las clasificaciones jeas
		/// </summary>
		public List<Rh_Clasificacion> GetAllClasificacion()
		{
			string spName = "SP_RH_OBTIENE_CLASIFICACION";
			using (var conexion = new SqlConnection(connectionString))
			{

				var clasificacion = conexion.Query<Rh_Clasificacion>(spName, commandType: CommandType.StoredProcedure);

				return clasificacion.ToList();
			}
		}
	}
}

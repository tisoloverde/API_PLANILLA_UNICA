using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioNivelOcupacional : IRepositorioNivelOcupacional
	{
		private readonly string? connectionString;
		public RepositorioNivelOcupacional(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los niveles ocupacionales
		/// </summary>
		public List<Rh_Nivel_Ocupacional> GetAllNivelOcupacional()
		{
			string spName = "SP_RH_OBTIENE_NIVEL_OCUPACIONAL";
			using (var conexion = new SqlConnection(connectionString))
			{

				var nivelesOcupacional = conexion.Query<Rh_Nivel_Ocupacional>(spName, commandType: CommandType.StoredProcedure);

				return nivelesOcupacional.ToList();
			}
		}
	}
}

using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioNivelEstudio : IRepositorioNivelEstudio
	{
		private readonly string? connectionString;
		public RepositorioNivelEstudio(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los niveles de estudio
		/// </summary>
		public List<Rh_Nivel_Estudio> GetAllNivelEstudio()
		{
			string spName = "SP_RH_OBTIENE_NIVEL_ESTUDIO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var nivelesEstudio = conexion.Query<Rh_Nivel_Estudio>(spName, commandType: CommandType.StoredProcedure);

				return nivelesEstudio.ToList();
			}
		}
	}
}

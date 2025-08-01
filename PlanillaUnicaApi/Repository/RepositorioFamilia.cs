using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioFamilia : IRepositorioFamilia
	{
		private readonly string? connectionString;
		public RepositorioFamilia(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas las familias de cargos
		/// </summary>
		public List<Rh_Familia> GetAllFamilia()
		{
			string spName = "SP_RH_OBTIENE_FAMILIA";
			using (var conexion = new SqlConnection(connectionString))
			{

				var familia = conexion.Query<Rh_Familia>(spName, commandType: CommandType.StoredProcedure);

				return familia.ToList();
			}
		}
	}
}

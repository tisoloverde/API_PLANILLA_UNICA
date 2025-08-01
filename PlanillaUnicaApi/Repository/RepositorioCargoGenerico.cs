using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioCargoGenerico : IRepositorioCargoGenerico
	{
		private readonly string? connectionString;
		public RepositorioCargoGenerico(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas los cargos genericos
		/// </summary>
		public List<Rh_Cargo_Generico> GetAllCargoGenerico()
		{
			string spName = "SP_RH_OBTIENE_CARGO_GENERICO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var cargoGenerico = conexion.Query<Rh_Cargo_Generico>(spName, commandType: CommandType.StoredProcedure);

				return cargoGenerico.ToList();
			}
		}
	}
}

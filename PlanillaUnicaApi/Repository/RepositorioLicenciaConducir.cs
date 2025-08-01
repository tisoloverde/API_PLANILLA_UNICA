using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioLicenciaConducir : IRepositorioLicenciaConducir
	{
		private readonly string? connectionString;
		public RepositorioLicenciaConducir(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los tipos de licencia de conducir
		/// </summary>
		public List<Rh_Licencia_Conducir> GetAllLicenciaConducir()
		{
			string spName = "SP_RH_OBTIENE_LICENCIA_CONDUCIR";
			using (var conexion = new SqlConnection(connectionString))
			{

				var licenciasConducir = conexion.Query<Rh_Licencia_Conducir>(spName, commandType: CommandType.StoredProcedure);

				return licenciasConducir.ToList();
			}
		}
	}
}

using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioJubilado : IRepositorioJubilado
	{
		private readonly string? connectionString;
		public RepositorioJubilado(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas tipos de jubilado
		/// </summary>
		public List<Rh_Jubilado> GetAllJubilado()
		{
			string spName = "SP_RH_OBTIENE_JUBILADO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var jubilado = conexion.Query<Rh_Jubilado>(spName, commandType: CommandType.StoredProcedure);

				return jubilado.ToList();
			}
		}
	}
}

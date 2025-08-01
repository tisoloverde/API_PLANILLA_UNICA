using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioSistemaPension : IRepositorioSistemaPension
	{
		private readonly string? connectionString;
		public RepositorioSistemaPension(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los sistemas de pension
		/// </summary>
		public List<Rh_Sistema_Pension> GetAllSistemaPension()
		{
			string spName = "SP_RH_OBTIENE_SISTEMA_PENSION";
			using (var conexion = new SqlConnection(connectionString))
			{

				var sistemaPension = conexion.Query<Rh_Sistema_Pension>(spName, commandType: CommandType.StoredProcedure);

				return sistemaPension.ToList();
			}
		}
	}
}

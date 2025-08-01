using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioTipoAbono : IRepositorioTipoAbono
	{
		private readonly string? connectionString;
		public RepositorioTipoAbono(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas los tipos de abono
		/// </summary>
		public List<Rh_Tipo_Abono> GetAllTipoAbono()
		{
			string spName = "SP_RH_OBTIENE_TIPO_ABONO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var tiposAbono = conexion.Query<Rh_Tipo_Abono>(spName, commandType: CommandType.StoredProcedure);

				return tiposAbono.ToList();
			}
		}
	}
}

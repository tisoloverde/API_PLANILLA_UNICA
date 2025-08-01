using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioTipoContrato : IRepositorioTipoContrato
	{
		private readonly string? connectionString;
		public RepositorioTipoContrato(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas los tipos de contrato
		/// </summary>
		public List<Rh_Tipo_Contrato> GetAllTipoContrato()
		{
			string spName = "SP_RH_OBTIENE_TIPO_CONTRATO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var tiposContrato = conexion.Query<Rh_Tipo_Contrato>(spName, commandType: CommandType.StoredProcedure);

				return tiposContrato.ToList();
			}
		}
	}
}

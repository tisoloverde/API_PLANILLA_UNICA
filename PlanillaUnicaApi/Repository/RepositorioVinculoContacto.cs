using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioVinculoContacto : IRepositorioVinculoContacto
	{
		private readonly string? connectionString;
		public RepositorioVinculoContacto(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todas los vinculos de contacto
		/// </summary>
		public List<Rh_Vinculo_Contacto> GetAllVinculoContacto()
		{
			string spName = "SP_RH_OBTIENE_VINCULO_CONTACTO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var vinculosContacto = conexion.Query<Rh_Vinculo_Contacto>(spName, commandType: CommandType.StoredProcedure);

				return vinculosContacto.ToList();
			}
		}
	}
}

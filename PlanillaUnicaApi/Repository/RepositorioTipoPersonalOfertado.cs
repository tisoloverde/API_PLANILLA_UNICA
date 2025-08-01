using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository 
{
	public class RepositorioTipoPersonalOfertado : IRepositorioTipoPersonalOfertado
	{
		private readonly string? connectionString;
		public RepositorioTipoPersonalOfertado(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		/// <summary>
		/// Método que devuelve todos los tipos de personal ofertado
		/// </summary>
		public List<Rh_Tipo_Personal_Ofertado> GetAllTipoPersonalOfertado()
		{
			string spName = "SP_RH_OBTIENE_TIPO_PERSONAL_OFERTADO";
			using (var conexion = new SqlConnection(connectionString))
			{

				var tiposPersonalOfertado = conexion.Query<Rh_Tipo_Personal_Ofertado>(spName, commandType: CommandType.StoredProcedure);

				return tiposPersonalOfertado.ToList();
			}
		}
	}
}

using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioAsistencia: IRepositorioAsistencia
	{
		private readonly string? connectionString;
		public RepositorioAsistencia(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		public List<Rh_Calendario_Semanas> ObtieneSemanasAno(int ano)
		{
			string spName = "SP_RH_OBTIENE_SEMANAS_ANO";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@Ano", ano);
				var semanasLista = conexion.Query<Rh_Calendario_Semanas>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

				return semanasLista.ToList();
			}
		}

		/// <summary>
		/// Método que devuelve los conceptos de asistencia (marcas)
		/// </summary>
		public List<Rh_Asistencia_Concepto> GetAllAsistenciaConceptos()
		{
			string spName = "SP_RH_OBTIENE_ASISTENCIA_CONCEPTO";
			using (var conexion = new SqlConnection(connectionString))
			{
				var asistenciaConceptos = conexion.Query<Rh_Asistencia_Concepto>(spName, commandType: CommandType.StoredProcedure);
				return asistenciaConceptos.ToList();
			}
		}

		public List<AsistenciaLista> ObtieneAsistenciaCentroPeriodoSemana(decimal CentroCosto, int periodo, string fechaInicio, string fechaTermino)
		{
			string spName = "SP_RH_OBTIENE_ASISTENCIA_CC_PERIODO_SEMANA";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@GENCENCOS_ID", CentroCosto);
				dynamicParameters.Add("@PERIODO", periodo);
				dynamicParameters.Add("@FECHA_INICIO", fechaInicio);
				dynamicParameters.Add("@FECHA_TERMINO", fechaTermino);
				var asistenciaLista = conexion.Query<AsistenciaLista>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

				return asistenciaLista.ToList();
			}
		}

	}
}

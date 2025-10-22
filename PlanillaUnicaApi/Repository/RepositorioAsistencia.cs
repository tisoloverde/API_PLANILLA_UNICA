using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Models.Dto;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;
using static Dapper.SqlMapper;
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

		/// <summary>
		/// Método que permite insertar un registro de asistencia
		/// </summary>
		/// <param name="asistencias"></param>
		/// <returns></returns>
		public Resultado_ExecDto GrabaAsistencia(List<AsistenciaRegistro> asistencias)
		{
			Resultado_ExecDto resultado = new Resultado_ExecDto();
			SqlTransaction transaction = null;
			string spName = "SP_RH_INSERTA_ACTUALIZA_ASISTENCIA";
			using (var conexion = new SqlConnection(connectionString))
			{
				conexion.Open();
				using (transaction = conexion.BeginTransaction())
				{
					DynamicParameters dynamicParameters = new DynamicParameters();
					//Grabamos el listado de asistencia de los colaboradores enviados
					foreach (var asistencia in asistencias)
					{
						dynamicParameters = new DynamicParameters();
						dynamicParameters.Add("@RHCOL_ID", asistencia.Rhcol_Id);
						dynamicParameters.Add("@RHASICON_ID", asistencia.Rhasicon_Id);
						dynamicParameters.Add("@RHSIS_FECHA", asistencia.Rhsis_Fecha);
						dynamicParameters.Add("@RHSIS_H50", asistencia.Rhsis_H50);
						dynamicParameters.Add("@RHSIS_H100", asistencia.Rhsis_H100);
						dynamicParameters.Add("@RHSIS_ATRASO", asistencia.Rhsis_Atraso);
						dynamicParameters.Add("@RHSIS_OBSERVACION", asistencia.Rhsis_Observacion);
						dynamicParameters.Add("@ACCUSU_ID", asistencia.Accusu_Id);
						dynamicParameters.Add("@RHCARGEN_ID", asistencia.Rhcargen_Id);
						dynamicParameters.Add("@RHREF1_ID", asistencia.Rhref1_Id);
						dynamicParameters.Add("@RHREF2_ID", asistencia.Rhref2_Id);
						dynamicParameters.Add("@RHCARGEN_ID_B", asistencia.Rhcargen_Id_B);
						dynamicParameters.Add("@RHREF1_ID_B", asistencia.Rhref1_Id_B);
						dynamicParameters.Add("@RHREF2_ID_B", asistencia.Rhref2_Id_B);
						// Adding Output parameter.
						dynamicParameters.Add("@CANTIDAD", DbType.Int32, direction: ParameterDirection.Output);
						conexion.Execute(spName, dynamicParameters, transaction: transaction, commandType: CommandType.StoredProcedure);
						resultado.Cantidad = dynamicParameters.Get<int>("@CANTIDAD");
						if (resultado.Cantidad <=  0)
						{
							resultado.Estado = "ERROR";
							resultado.Mensaje = "Error al registrar asistencia";
							transaction.Rollback();
							return resultado;
						}
					}
					resultado.Estado = "OK";
					resultado.Mensaje = "Asistencia registrada correctamente";
					transaction.Commit();
				}
			}
			return resultado;
		}

	}
}

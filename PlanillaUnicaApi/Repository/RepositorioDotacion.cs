using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Models.Dto;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;

namespace PlanillaUnicaApi.Repository
{
	public class RepositorioDotacion : IRepositorioDotacion
	{
		private readonly string? connectionString;
		public RepositorioDotacion(IConfiguration configuration)
		{
			connectionString
				= configuration.GetConnectionString("DefaultConnection");
		}

		public List<DotacionLista> ObtieneDotacionLista(decimal centroCosto, decimal periodo)
		{
			string spName = "SP_RH_OBTIENE_DOTACION_LISTA";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@GENCENCOS_ID", centroCosto);
				dynamicParameters.Add("@PERIODO", periodo);
				var dotacionLista = conexion.Query<DotacionLista>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

				return dotacionLista.ToList();
			}
		}

		/// <summary>
		/// Método que permite crear un nuevo registro de dotacion
		/// </summary>
		/// <param name="dotacion"></param>
		/// <returns></returns>
		public Resultado_ExecDto CreateDotacion(Rh_Dotacion dotacion)
		{
			Resultado_ExecDto resultado = new Resultado_ExecDto();

			string spName = "SP_RH_INSERTA_DOTACION";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@GENCENCOS_ID", dotacion.Gencencos_Id);
				dynamicParameters.Add("@RHDOT_PERIODO", dotacion.Rhdot_Periodo);
				dynamicParameters.Add("@RHTIPPEROFE_ID", dotacion.Rhtipperofe_Id);
				dynamicParameters.Add("@RHCARGEN_ID_MANDANTE", dotacion.Rhcargen_Id_Mandante);
				dynamicParameters.Add("@RHCARGEN_ID_UNIFICADO", dotacion.Rhcargen_Id_Unificado);
				dynamicParameters.Add("@RHREF1_ID", dotacion.Rhref1_Id);
				dynamicParameters.Add("@RHREF2_ID", dotacion.Rhref2_Id);
				dynamicParameters.Add("@RHDOT_ENE", dotacion.Rhdot_Ene);
				dynamicParameters.Add("@RHDOT_FEB", dotacion.Rhdot_Feb);
				dynamicParameters.Add("@RHDOT_MAR", dotacion.Rhdot_Mar);
				dynamicParameters.Add("@RHDOT_ABR", dotacion.Rhdot_Abr);
				dynamicParameters.Add("@RHDOT_MAY", dotacion.Rhdot_May);
				dynamicParameters.Add("@RHDOT_JUN", dotacion.Rhdot_Jun);
				dynamicParameters.Add("@RHDOT_JUL", dotacion.Rhdot_Jul);
				dynamicParameters.Add("@RHDOT_AGO", dotacion.Rhdot_Ago);
				dynamicParameters.Add("@RHDOT_SEP", dotacion.Rhdot_Sep);
				dynamicParameters.Add("@RHDOT_OCT", dotacion.Rhdot_Oct);
				dynamicParameters.Add("@RHDOT_NOV", dotacion.Rhdot_Nov);
				dynamicParameters.Add("@RHDOT_DIC", dotacion.Rhdot_Dic);
				// Adding Output parameter.
				dynamicParameters.Add("@CANTIDAD", DbType.Int32, direction: ParameterDirection.Output);
				conexion.Execute(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
				resultado.Cantidad = dynamicParameters.Get<int>("@CANTIDAD");
				if (resultado.Cantidad > 0)
				{
					resultado.Estado = "OK";
					resultado.Mensaje = "Dotación creada correctamente";
				}
				else
				{
					resultado.Estado = "ERROR";
					resultado.Mensaje = "Error al crear el registro de dotación";
				}
			}
			return resultado;
		}

		/// <summary>
		/// Método que permite actualizar un registro de dotacion
		/// </summary>
		/// <param name="dotacion"></param>
		/// <returns></returns>
		public Resultado_ExecDto ActualizaDotacion(Rh_Dotacion dotacion)
		{
			Resultado_ExecDto resultado = new Resultado_ExecDto();

			string spName = "SP_RH_ACTUALIZA_DOTACION";
			using (var conexion = new SqlConnection(connectionString))
			{
				DynamicParameters dynamicParameters = new DynamicParameters();
				// Adding Input parameters.
				dynamicParameters.Add("@RHDOT_ID", dotacion.Rhdot_Id);
				dynamicParameters.Add("@GENCENCOS_ID", dotacion.Gencencos_Id);
				dynamicParameters.Add("@RHDOT_PERIODO", dotacion.Rhdot_Periodo);
				dynamicParameters.Add("@RHTIPPEROFE_ID", dotacion.Rhtipperofe_Id);
				dynamicParameters.Add("@RHCARGEN_ID_MANDANTE", dotacion.Rhcargen_Id_Mandante);
				dynamicParameters.Add("@RHCARGEN_ID_UNIFICADO", dotacion.Rhcargen_Id_Unificado);
				dynamicParameters.Add("@RHREF1_ID", dotacion.Rhref1_Id);
				dynamicParameters.Add("@RHREF2_ID", dotacion.Rhref2_Id);
				dynamicParameters.Add("@RHDOT_ENE", dotacion.Rhdot_Ene);
				dynamicParameters.Add("@RHDOT_FEB", dotacion.Rhdot_Feb);
				dynamicParameters.Add("@RHDOT_MAR", dotacion.Rhdot_Mar);
				dynamicParameters.Add("@RHDOT_ABR", dotacion.Rhdot_Abr);
				dynamicParameters.Add("@RHDOT_MAY", dotacion.Rhdot_May);
				dynamicParameters.Add("@RHDOT_JUN", dotacion.Rhdot_Jun);
				dynamicParameters.Add("@RHDOT_JUL", dotacion.Rhdot_Jul);
				dynamicParameters.Add("@RHDOT_AGO", dotacion.Rhdot_Ago);
				dynamicParameters.Add("@RHDOT_SEP", dotacion.Rhdot_Sep);
				dynamicParameters.Add("@RHDOT_OCT", dotacion.Rhdot_Oct);
				dynamicParameters.Add("@RHDOT_NOV", dotacion.Rhdot_Nov);
				dynamicParameters.Add("@RHDOT_DIC", dotacion.Rhdot_Dic);
				// Adding Output parameter.
				dynamicParameters.Add("@CANTIDAD", DbType.Int32, direction: ParameterDirection.Output);
				conexion.Execute(spName, dynamicParameters, commandType: CommandType.StoredProcedure);
				resultado.Cantidad = dynamicParameters.Get<int>("@CANTIDAD");
				if (resultado.Cantidad > 0)
				{
					resultado.Estado = "OK";
					resultado.Mensaje = "Dotación actualizada correctamente";
				}
				else
				{
					resultado.Estado = "ERROR";
					resultado.Mensaje = "Error al actualizar el registro de dotación";
				}
			}
			return resultado;
		}
	}
}

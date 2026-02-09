using Dapper;
using Microsoft.Data.SqlClient;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository.IRepository;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanillaUnicaApi.Repository
{
    public class RepositorioInformeAsistencia: IRepositorioInformeAsistencia
    {
        private readonly string? connectionString;
        public RepositorioInformeAsistencia(IConfiguration configuration)
        {
            connectionString
                = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Rh_Informe_Salida_He> ObtieneInformeHe50 (Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_EXCEL_HE50";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@FECHA_INICIO", informe.FechaInicio);
                dynamicParameters.Add("@FECHA_TERMINO", informe.FechaTermino);
                var he50 = conexion.Query<Rh_Informe_Salida_He>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

                return he50.ToList();
            }
        }

        public List<Rh_Informe_Salida_He> ObtieneInformeHe100(Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_EXCEL_HE100";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@FECHA_INICIO", informe.FechaInicio);
                dynamicParameters.Add("@FECHA_TERMINO", informe.FechaTermino);
                var he100 = conexion.Query<Rh_Informe_Salida_He>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

                return he100.ToList();
            }
        }

        public List<Rh_Informe_Salida_He> ObtieneInformeAtraso(Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_EXCEL_ATRASO";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@FECHA_INICIO", informe.FechaInicio);
                dynamicParameters.Add("@FECHA_TERMINO", informe.FechaTermino);
                var atrasos = conexion.Query<Rh_Informe_Salida_He>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

                return atrasos.ToList();
            }
        }

        public List<Rh_Informe_Falta_Permiso> ObtieneInformeFaltasPermisos(Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_FALTAS_PERMISOS";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@FECHA_INICIO", informe.FechaInicio);
                dynamicParameters.Add("@FECHA_TERMINO", informe.FechaTermino);
                
                var faltaspermisos = conexion.Query(spName, dynamicParameters, commandType: CommandType.StoredProcedure)
                    .Select(row => new Rh_Informe_Falta_Permiso
                    {
                        empleado_id = row.empleado_id?.ToString() ?? string.Empty,
                        contratos = ParseNullableInt(row.contratos),
                        tipo = row.tipo?.ToString() ?? string.Empty,
                        fecha_inicio = row.fecha_inicio?.ToString() ?? string.Empty,
                        fecha_termino = row.fecha_termino?.ToString() ?? string.Empty,
                        dias = ParseNullableDecimal(row.dias),
                        descripcion = row.descripcion?.ToString() ?? string.Empty,
                        tipo_medio_dia = row.tipo_medio_dia?.ToString() ?? string.Empty,
                        envia_email_supervidor = row.envia_email_supervidor?.ToString() ?? string.Empty,
                        numero_licencia = row.numero_licencia?.ToString() ?? string.Empty,
                        dias_a_pagar = ParseNullableDecimal(row.dias_a_pagar),
                        no_rebaja = ParseNullableDecimal(row.no_rebaja),
                        fecha_concepcion = row.fecha_concepcion?.ToString() ?? string.Empty,
                        fecha_aplicacion = row.fecha_aplicacion?.ToString() ?? string.Empty,
                        goce_sueldo = ParseNullableDecimal(row.goce_sueldo),
                        subtipo_ausencia = row.subtipo_ausencia?.ToString() ?? string.Empty,
                        medico_tratante = row.medico_tratante?.ToString() ?? string.Empty,
                        especialidad = row.especialidad?.ToString() ?? string.Empty
                    }).ToList();

                return faltaspermisos;
            }
        }

        private int? ParseNullableInt(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            
            if (int.TryParse(value.ToString(), out int result))
                return result;
            
            return null;
        }

        private decimal? ParseNullableDecimal(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            
            if (decimal.TryParse(value.ToString(), out decimal result))
                return result;
            
            return null;
        }

        public List<Rh_Informe_General_Mensual> ObtieneInformeGeneralMensual(Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_GENERAL_MENSUAL";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@PERIODO", informe.Periodo);
                var generalmensual = conexion.Query<Rh_Informe_General_Mensual>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

                return generalmensual.ToList();
            }
        }

        public List<Rh_Informe_Validacion_Mensual> ObtieneInformeValidacionMensual(Rh_Informe_Asistencia informe)
        {
            string spName = "SP_RH_INFORME_VALIDACION_MENSUAL";
            using (var conexion = new SqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                // Adding Input parameters.
                dynamicParameters.Add("@GENCENCOS_ID", informe.CentroCosto);
                dynamicParameters.Add("@PERIODO", informe.Periodo);
                var validacionmensual = conexion.Query<Rh_Informe_Validacion_Mensual>(spName, dynamicParameters, commandType: CommandType.StoredProcedure);

                return validacionmensual.ToList();
            }
        }
    }
}

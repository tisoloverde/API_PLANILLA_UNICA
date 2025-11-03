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

    }
}

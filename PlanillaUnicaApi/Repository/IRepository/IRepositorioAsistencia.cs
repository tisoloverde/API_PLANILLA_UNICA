using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Models.Dto;

namespace PlanillaUnicaApi.Repository.IRepository
{
	public interface IRepositorioAsistencia
	{
		public List<Rh_Calendario_Semanas> ObtieneSemanasAno(int ano);
		public List<Rh_Asistencia_Concepto> GetAllAsistenciaConceptos();
		public List<AsistenciaLista> ObtieneAsistenciaCentroPeriodoSemana(decimal CentroCosto, int periodo, string fechaInicio, string fechaTermino);
		public Resultado_ExecDto GrabaAsistencia(List<AsistenciaRegistro> asistencias);
	}
}

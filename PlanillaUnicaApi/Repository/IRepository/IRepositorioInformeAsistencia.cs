using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Repository.IRepository
{
    public interface IRepositorioInformeAsistencia
    {
        public List<Rh_Informe_Salida_He> ObtieneInformeHe50(Rh_Informe_Asistencia informe);
        public List<Rh_Informe_Salida_He> ObtieneInformeHe100(Rh_Informe_Asistencia informe);
        public List<Rh_Informe_Salida_He> ObtieneInformeAtraso(Rh_Informe_Asistencia informe);
    }
}

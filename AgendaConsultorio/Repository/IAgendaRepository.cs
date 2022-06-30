using AgendaConsultorio.Models;
using System.Collections.Generic;

namespace AgendaConsultorio.Repository
{
    public interface IAgendaRepository
    {

        void Agendar(AgendaVO agenda);

        void CancelarAgenda(AgendaVO agenda);

        List<AgendaVO> ListaAgendas();



    }
}

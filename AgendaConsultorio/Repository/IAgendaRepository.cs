using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Repository
{
    public interface IAgendaRepository
    {

        void Agendar(AgendaVO agenda);
        void CancelarAgenda(AgendaVO agenda);
        List<AgendaVO> ListaAgendas();



    }
}

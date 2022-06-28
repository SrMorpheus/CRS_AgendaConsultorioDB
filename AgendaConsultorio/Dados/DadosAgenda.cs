using System;
using System.Collections.Generic;
using System.Text;
using AgendaConsultorio.Models;

namespace AgendaConsultorio.Dados

{
    public class DadosAgenda
    {

        private static List<AgendaVO> _baseAgenda = new List<AgendaVO>();

        public static void Agendar(AgendaVO agenda)
        {

            _baseAgenda.Add(agenda);

        }



        public static void CancelarAgenda(AgendaVO agenda)
        {

            _baseAgenda.Remove(agenda);

        }


        public static List<AgendaVO> listaAgendas()
        {

            return _baseAgenda;

        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AgendaConsultorio.Models;

namespace AgendaConsultorio.Dados

{
    public class DadosAgenda
    {

        private static List<Agenda> _baseAgenda = new List<Agenda>();

        public static void Agendar(Agenda agenda)
        {

            _baseAgenda.Add(agenda);

        }



        public static void CancelarAgenda(Agenda agenda)
        {

            _baseAgenda.Remove(agenda);

        }


        public static List<Agenda> listaAgendas()
        {

            return _baseAgenda;

        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Models
{
    public class Agenda
    {
        public long CPF { get; set; }

        public DateTime DataConsulta { get; private set; }

        public DateTime HoraInicial { get; private set; }

        public DateTime HoraFinal { get; private set; }

        public Paciente Paciente { get;  set; }




        public Agenda(long cpf , DateTime dataConsulta , DateTime horaInicial, DateTime horaFinal)
        {
            this.CPF = cpf;
            
            this.DataConsulta = dataConsulta;

            this.HoraInicial = horaInicial;

            this.HoraFinal = horaFinal;


        }





    }
}

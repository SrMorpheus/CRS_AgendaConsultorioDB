using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AgendaConsultorio.Models
{
    public class Agenda : IEquatable<Agenda>
    {
        public long CPF { get; set; }

        public DateTime DataConsulta { get; private set; }

        public DateTime HoraInicial { get; private set; }

        public DateTime HoraFinal { get; private set; }

        public Paciente Paciente { get; set; }




        public Agenda(long cpf, DateTime dataConsulta, DateTime horaInicial, DateTime horaFinal)
        {
            this.CPF = cpf;

            this.DataConsulta = dataConsulta;

            this.HoraInicial = horaInicial;

            this.HoraFinal = horaFinal;

            Paciente.adicionarAgendaPaciente(this);
            

        }

        public override bool Equals(object obj)
        {

            return this.Equals(obj as Agenda);

        }

        public bool Equals(Agenda other)
        {

            if (other == null)
                return false;

            return this.DataConsulta.Equals(other.DataConsulta) &&
         (
             object.ReferenceEquals(this.DataConsulta, other.DataConsulta) ||
             this.DataConsulta != null &&
             this.DataConsulta.Equals(other.DataConsulta)
         ) &&
         (
             object.ReferenceEquals(this.HoraInicial, other.HoraInicial) ||
             this.HoraInicial != null &&
             this.HoraInicial.Equals(other.HoraInicial)
         ) &&
         (
          object.ReferenceEquals(this.HoraFinal, other.HoraFinal) ||
             this.HoraFinal != null &&
             this.HoraFinal.Equals(other.HoraFinal));

        }
    }

    }


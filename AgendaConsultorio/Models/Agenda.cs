using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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




        public Agenda(long cpf, DateTime dataConsulta, DateTime horaInicial, DateTime horaFinal, Paciente paciente)
        {
            this.CPF = cpf;

            this.DataConsulta = dataConsulta;

            this.HoraInicial = horaInicial;

            this.HoraFinal = horaFinal;

            this.Paciente = paciente;

            this.Paciente.adicionarAgendaPaciente(this);
            

        }


        public static DateTime ConverterHora(string hora)
        {
            DateTime horaConverter;

            var horaFormat = hora.Substring(0, 2);

            var minuntosFormat = hora.Substring(2, 2);

            hora = horaFormat + ":" + minuntosFormat;



            bool horaValida = DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaConverter);

            return horaConverter;


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

        public override string ToString()
        {
            return DataConsulta + " " + HoraInicial + " " +  HoraFinal + " " + CPF;
        }


    }

  }


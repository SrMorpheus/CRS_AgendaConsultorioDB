using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace AgendaConsultorio.Models
{
    public class Agenda : IEquatable<Agenda>
    {



        private DateTime _dataHoraConsulta;
        public long CPF { get; set; }

        public DateTime DataConsulta { get; private set; }

        public DateTime HoraInicial { get; private set; }

        public DateTime HoraFinal { get; private set; }


        public DateTime DataHoraConsulta
        {

            get { return _dataHoraConsulta;  }

            private set { _dataHoraConsulta = AgendaDataHora(); }
        
        
        }
        public Paciente Paciente { get; set; }




        public Agenda(long cpf, DateTime dataConsulta, DateTime horaInicial, DateTime horaFinal, Paciente paciente)
        {
            this.CPF = cpf;

            this.DataConsulta = dataConsulta;

            this.HoraInicial = horaInicial;

            this.HoraFinal = horaFinal;

            this.Paciente = paciente;

            this.DataHoraConsulta = AgendaDataHora(); 


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


        public string AgendaPacienteData()
        {

            var retorno = "Agendado para: " + this.DataConsulta.ToString("dd/MM/yyyy");
                       

            return retorno;


        }




        public DateTime AgendaDataHora()
        {


            DateTime dataHora;


            var horaFormat = this.HoraInicial.ToString("HH:mm");

            var DataFormat = this.DataConsulta.ToString("dd/MM/yyyy");


            var dataHoraFormat = DataFormat + " " + horaFormat;


            bool datavalida = DateTime.TryParseExact(dataHoraFormat, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora);

            return dataHora;

          
        


        }


        public static DateTime AgendaDataHora(string dataConsulta , string horaInical)
        {


            DateTime dataHora;


            var horaFormat = Agenda.ConverterHora(horaInical);


            var dataHoraFormat = dataConsulta + " " + horaFormat.ToString("HH:mm");


            bool datavalida = DateTime.TryParseExact(dataHoraFormat, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora);

            return dataHora;

          




        }




        public string AgendaPacienteHora()
        {

            var retorno = this.HoraInicial.ToString("HH:mm") + " ás " + this.HoraFinal.ToString("HH:mm");

            return retorno;


        }
          

           



    }

  }


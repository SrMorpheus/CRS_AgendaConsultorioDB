using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaConsultorio.Models
{
  
    public class Agenda
    {

      
        public int Id { get; set; }
       
        public long CPF { get; set; }
     
        public DateTime DataConsulta { get; set; }
       
        public DateTime HoraInicial { get; set; }

        public DateTime HoraFinal { get; set; }
    
        public DateTime DataHoraConsulta { get; set; }

        public int PacienteID { get; set; }

        public Paciente Paciente { get; set; }


    }
}
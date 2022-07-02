using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaConsultorio.Models
{

    
    public class Paciente
    {

        public int Id { get; set; }  
        
        public long CPF { get; set; }
       
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<Agenda> Agendas { get; set; }

    }
}

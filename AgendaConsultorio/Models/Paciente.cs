using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaConsultorio.Models
{

    [Table("Tbl_Paciente")]
    public class Paciente
    {

        [Column("Cod_Paciente")]
        public int Id { get; set; }

        [Column("CPF_Paciente")]

        public long CPF { get; set; }

        [Column("Nome_Paciente")]

        public string Nome { get; set; }

        [Column("Data_Nascimento")]

        public DateTime DataNascimento { get; set; }


        public List<Agenda> Agendas { get; set; }

    }
}

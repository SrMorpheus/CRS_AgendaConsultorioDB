using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaConsultorio.Models
{
    [Table("Tbl_Agenda")]
    public class Agenda
    {

        [Column("Cod_Agenda")]
        public int Id { get; set; }

        [Column("CPF_Paciente_Agenda")]
        public long CPF { get; set; }

        [Column("Data_Consulta")]
        public DateTime DataConsulta { get; set; }

        [Column("Hora_Inicial")]
        public DateTime HoraInicial { get; set; }

        [Column("Hora_Final")]
        public DateTime HoraFinal { get; set; }

        [Column("DATA_Hora_Consulta")]
        public DateTime DataHoraConsulta { get; set; }
 
        [Column("FK_Paciente")]
        public int PacienteID { get; set; }
        public Paciente Paciente { get; set; }


    }
}
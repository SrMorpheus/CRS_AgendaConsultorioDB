using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AgendaConsultorio.Models;

namespace AgendaConsultorio.Dados
{
    public class ConsultorioContexto : DbContext
    {

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Agenda> Agendas  { get; set; }



        public ConsultorioContexto()
        { }

        public ConsultorioContexto(DbContextOptions<ConsultorioContexto> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsultorioDB;Trusted_Connection=true;");
            }
        }


    }
}

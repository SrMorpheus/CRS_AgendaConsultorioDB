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

       protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Paciente>()
                .ToTable("Tbl_Paciente");

            modelBuilder.Entity<Paciente>()
                .Property(P => P.Id)
                .HasColumnName("Cod_Paciente");

            modelBuilder.Entity<Paciente>()
                .Property(P => P.CPF)
                .HasColumnName("CPF_Paciente")
                .HasColumnType("BIGINT")
                .IsRequired();

            modelBuilder.Entity<Paciente>()
               .Property(P => P.Nome)
               .HasColumnName("Nome_Paciente")
               .HasColumnType("VARCHAR(90)")
               .IsRequired();

            modelBuilder.Entity<Paciente>()
               .Property(P => P.DataNascimento)
               .HasColumnName("Data_Nascimento")
               .HasColumnType("DATE")
               .IsRequired();

            


            modelBuilder.Entity<Agenda>()
              .ToTable("Tbl_Agenda");


            modelBuilder.Entity<Agenda>()
                .Property(A => A.Id)
                .HasColumnName("Cod_Agenda");

            modelBuilder.Entity<Agenda>()
                .Property(A => A.CPF)
                .HasColumnName("CPF_Paciente_Agenda")
                .HasColumnType("BIGINT")
                .IsRequired();

            modelBuilder.Entity<Agenda>()
               .Property(A => A.DataConsulta)
               .HasColumnName("Data_Consulta")
               .HasColumnType("DATE")
               .IsRequired();

            modelBuilder.Entity<Agenda>()
               .Property(A => A.HoraInicial)
               .HasColumnName("Hora_Inicial")
               .HasColumnType("DATETIME")
               .IsRequired();


            modelBuilder.Entity<Agenda>()
               .Property(A => A.HoraFinal)
               .HasColumnName("Hora_Final")
               .HasColumnType("DATETIME")
               .IsRequired();

            modelBuilder.Entity<Agenda>()
               .Property(A => A.DataHoraConsulta)
               .HasColumnName("DATA_Hora_Consulta")
               .HasColumnType("DATETIME")
               .IsRequired();

            modelBuilder.Entity<Agenda>()
             .HasOne(p => p.Paciente)
             .WithMany(b => b.Agendas)
             .HasForeignKey(p => p.PacienteID);
            










        }
    }
}

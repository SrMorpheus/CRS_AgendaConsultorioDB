using AgendaConsultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaConsultorio.Dados.Configuracao
{
    public class AgendaEntityTypeConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {


            builder
              .ToTable("Tbl_Agenda");


            builder
                .Property(A => A.Id)
                .HasColumnName("Cod_Agenda");

            builder
                .Property(A => A.CPF)
                .HasColumnName("CPF_Paciente_Agenda")
                .HasColumnType("BIGINT")
                .IsRequired();

            builder
               .Property(A => A.DataConsulta)
               .HasColumnName("Data_Consulta")
               .HasColumnType("DATE")
               .IsRequired();

            builder
               .Property(A => A.HoraInicial)
               .HasColumnName("Hora_Inicial")
               .HasColumnType("DATETIME")
               .IsRequired();


            builder
               .Property(A => A.HoraFinal)
               .HasColumnName("Hora_Final")
               .HasColumnType("DATETIME")
               .IsRequired();

            builder
               .Property(A => A.DataHoraConsulta)
               .HasColumnName("DATA_Hora_Consulta")
               .HasColumnType("DATETIME")
               .IsRequired();

            builder
             .HasOne(p => p.Paciente)
             .WithMany(b => b.Agendas)
             .HasForeignKey(p => p.PacienteID);


        }
    }
}

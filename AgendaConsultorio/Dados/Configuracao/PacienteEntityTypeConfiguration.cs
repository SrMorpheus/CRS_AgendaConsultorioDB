using AgendaConsultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaConsultorio.Dados.Configuracao
{
    public class PacienteEntityTypeConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {

            builder
              .ToTable("Tbl_Paciente");

            builder
                .Property(P => P.Id)
                .HasColumnName("Cod_Paciente");

            builder
                .Property(P => P.CPF)
                .HasColumnName("CPF_Paciente")
                .HasColumnType("BIGINT")
                .IsRequired();

            builder
               .Property(P => P.Nome)
               .HasColumnName("Nome_Paciente")
               .HasColumnType("VARCHAR(90)")
               .IsRequired();

            builder
               .Property(P => P.DataNascimento)
               .HasColumnName("Data_Nascimento")
               .HasColumnType("DATE")
               .IsRequired();


        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaConsultorio.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Paciente",
                columns: table => new
                {
                    Cod_Paciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF_Paciente = table.Column<long>(type: "BIGINT", nullable: false),
                    Nome_Paciente = table.Column<string>(type: "VARCHAR(90)", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Paciente", x => x.Cod_Paciente);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Agenda",
                columns: table => new
                {
                    Cod_Agenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF_Paciente_Agenda = table.Column<long>(type: "BIGINT", nullable: false),
                    Data_Consulta = table.Column<DateTime>(type: "DATE", nullable: false),
                    Hora_Inicial = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Hora_Final = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DATA_Hora_Consulta = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PacienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agenda", x => x.Cod_Agenda);
                    table.ForeignKey(
                        name: "FK_Tbl_Agenda_Tbl_Paciente_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Tbl_Paciente",
                        principalColumn: "Cod_Paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Agenda_PacienteID",
                table: "Tbl_Agenda",
                column: "PacienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Agenda");

            migrationBuilder.DropTable(
                name: "Tbl_Paciente");
        }
    }
}

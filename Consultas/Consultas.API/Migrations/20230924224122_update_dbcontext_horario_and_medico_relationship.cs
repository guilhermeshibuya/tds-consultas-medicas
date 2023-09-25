using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultas.API.Migrations
{
    /// <inheritdoc />
    public partial class update_dbcontext_horario_and_medico_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoConsulta",
                table: "Consultas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HorarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMedico = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHorario = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioModel_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioModel_IdMedico",
                table: "HorarioModel",
                column: "IdMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioModel");

            migrationBuilder.DropColumn(
                name: "TipoConsulta",
                table: "Consultas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultas.API.Migrations
{
    /// <inheritdoc />
    public partial class ondelete_medico_and_especialidade_removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

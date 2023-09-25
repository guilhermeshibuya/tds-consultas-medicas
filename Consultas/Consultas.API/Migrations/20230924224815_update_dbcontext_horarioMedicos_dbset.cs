using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultas.API.Migrations
{
    /// <inheritdoc />
    public partial class update_dbcontext_horarioMedicos_dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioModel_Medicos_IdMedico",
                table: "HorarioModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HorarioModel",
                table: "HorarioModel");

            migrationBuilder.RenameTable(
                name: "HorarioModel",
                newName: "HorariosMedico");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioModel_IdMedico",
                table: "HorariosMedico",
                newName: "IX_HorariosMedico_IdMedico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HorariosMedico",
                table: "HorariosMedico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HorariosMedico",
                table: "HorariosMedico");

            migrationBuilder.RenameTable(
                name: "HorariosMedico",
                newName: "HorarioModel");

            migrationBuilder.RenameIndex(
                name: "IX_HorariosMedico_IdMedico",
                table: "HorarioModel",
                newName: "IX_HorarioModel_IdMedico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HorarioModel",
                table: "HorarioModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioModel_Medicos_IdMedico",
                table: "HorarioModel",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

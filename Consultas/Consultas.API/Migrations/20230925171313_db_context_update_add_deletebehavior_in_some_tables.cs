using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultas.API.Migrations
{
    /// <inheritdoc />
    public partial class db_context_update_add_deletebehavior_in_some_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "HorariosMedico",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "HorariosMedico",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosMedico_Medicos_IdMedico",
                table: "HorariosMedico",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

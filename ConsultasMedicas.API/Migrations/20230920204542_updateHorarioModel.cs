using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultasMedicas.API.Migrations
{
    /// <inheritdoc />
    public partial class updateHorarioModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioModel_Medicos_MedicoIdMedico",
                table: "HorarioModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.RenameColumn(
                name: "MedicoIdMedico",
                table: "HorarioModel",
                newName: "MedicoModelIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioModel_MedicoIdMedico",
                table: "HorarioModel",
                newName: "IX_HorarioModel_MedicoModelIdMedico");

            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "HorarioModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioModel_Medicos_MedicoModelIdMedico",
                table: "HorarioModel",
                column: "MedicoModelIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioModel_Medicos_MedicoModelIdMedico",
                table: "HorarioModel");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "HorarioModel");

            migrationBuilder.RenameColumn(
                name: "MedicoModelIdMedico",
                table: "HorarioModel",
                newName: "MedicoIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioModel_MedicoModelIdMedico",
                table: "HorarioModel",
                newName: "IX_HorarioModel_MedicoIdMedico");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeIdEspecialidade",
                table: "Medicos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeIdEspecialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioModel_Medicos_MedicoIdMedico",
                table: "HorarioModel",
                column: "MedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeIdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade");
        }
    }
}

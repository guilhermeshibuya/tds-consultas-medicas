using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultasMedicas.API.Migrations
{
    /// <inheritdoc />
    public partial class modelconsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Recepcionistas_IdRecepcionista",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioModel_Medicos_IdMedico",
                table: "HorarioModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdRecepcionista",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "IdMedico",
                table: "HorarioModel",
                newName: "MedicoIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioModel_IdMedico",
                table: "HorarioModel",
                newName: "IX_HorarioModel_MedicoIdMedico");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeIdEspecialidade",
                table: "Medicos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoModelIdMedico",
                table: "Consultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteModelIdPaciente",
                table: "Consultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeIdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoModelIdMedico",
                table: "Consultas",
                column: "MedicoModelIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteModelIdPaciente",
                table: "Consultas",
                column: "PacienteModelIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                column: "RecepcionistaModelIdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoModelIdMedico",
                table: "Consultas",
                column: "MedicoModelIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteModelIdPaciente",
                table: "Consultas",
                column: "PacienteModelIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                column: "RecepcionistaModelIdRecepcionista",
                principalTable: "Recepcionistas",
                principalColumn: "IdRecepcionista");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoModelIdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteModelIdPaciente",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaModelIdRecepcionista",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioModel_Medicos_MedicoIdMedico",
                table: "HorarioModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_MedicoModelIdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PacienteModelIdPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_RecepcionistaModelIdRecepcionista",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "MedicoModelIdMedico",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PacienteModelIdPaciente",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "RecepcionistaModelIdRecepcionista",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "MedicoIdMedico",
                table: "HorarioModel",
                newName: "IdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioModel_MedicoIdMedico",
                table: "HorarioModel",
                newName: "IX_HorarioModel_IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdRecepcionista",
                table: "Consultas",
                column: "IdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Recepcionistas_IdRecepcionista",
                table: "Consultas",
                column: "IdRecepcionista",
                principalTable: "Recepcionistas",
                principalColumn: "IdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioModel_Medicos_IdMedico",
                table: "HorarioModel",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade");
        }
    }
}

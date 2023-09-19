using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultasMedicas.API.Migrations
{
    /// <inheritdoc />
    public partial class MedicoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdMedico",
                table: "Medicos");

            migrationBuilder.AddColumn<int>(
                name: "IdEspecialidade",
                table: "Medicos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "IdEspecialidade",
                table: "Medicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_IdMedico",
                table: "Medicos",
                column: "IdMedico",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

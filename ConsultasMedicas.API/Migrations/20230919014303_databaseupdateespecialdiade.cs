using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultasMedicas.API.Migrations
{
    /// <inheritdoc />
    public partial class databaseupdateespecialdiade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_IdEspecialidade",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

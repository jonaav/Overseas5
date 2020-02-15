using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class correccion_evaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Curso",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Curso",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

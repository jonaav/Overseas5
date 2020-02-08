using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class modifiedTraduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoCursoTipoEvaluacion_TipoCurso_IdTipoCurso",
                table: "TipoCursoTipoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoCursoTipoEvaluacion_TipoEvaluacion_IdTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Traduccion_Docente_IdDocente",
                table: "Traduccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCursoTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion");

            migrationBuilder.RenameTable(
                name: "TipoCursoTipoEvaluacion",
                newName: "TCursoTEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_TipoCursoTipoEvaluacion_IdTipoEvaluacion",
                table: "TCursoTEvaluacion",
                newName: "IX_TCursoTEvaluacion_IdTipoEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_TipoCursoTipoEvaluacion_IdTipoCurso",
                table: "TCursoTEvaluacion",
                newName: "IX_TCursoTEvaluacion_IdTipoCurso");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Traduccion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Curso",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TCursoTEvaluacion",
                table: "TCursoTEvaluacion",
                column: "idTipoCursoTipoEvaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TCursoTEvaluacion_TipoCurso_IdTipoCurso",
                table: "TCursoTEvaluacion",
                column: "IdTipoCurso",
                principalTable: "TipoCurso",
                principalColumn: "IdTipoCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TCursoTEvaluacion_TipoEvaluacion_IdTipoEvaluacion",
                table: "TCursoTEvaluacion",
                column: "IdTipoEvaluacion",
                principalTable: "TipoEvaluacion",
                principalColumn: "IdTipoEvaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traduccion_Docente_IdDocente",
                table: "Traduccion",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TCursoTEvaluacion_TipoCurso_IdTipoCurso",
                table: "TCursoTEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_TCursoTEvaluacion_TipoEvaluacion_IdTipoEvaluacion",
                table: "TCursoTEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Traduccion_Docente_IdDocente",
                table: "Traduccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TCursoTEvaluacion",
                table: "TCursoTEvaluacion");

            migrationBuilder.RenameTable(
                name: "TCursoTEvaluacion",
                newName: "TipoCursoTipoEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_TCursoTEvaluacion_IdTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion",
                newName: "IX_TipoCursoTipoEvaluacion_IdTipoEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_TCursoTEvaluacion_IdTipoCurso",
                table: "TipoCursoTipoEvaluacion",
                newName: "IX_TipoCursoTipoEvaluacion_IdTipoCurso");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Traduccion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDocente",
                table: "Curso",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCursoTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion",
                column: "idTipoCursoTipoEvaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Docente_IdDocente",
                table: "Curso",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCursoTipoEvaluacion_TipoCurso_IdTipoCurso",
                table: "TipoCursoTipoEvaluacion",
                column: "IdTipoCurso",
                principalTable: "TipoCurso",
                principalColumn: "IdTipoCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCursoTipoEvaluacion_TipoEvaluacion_IdTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion",
                column: "IdTipoEvaluacion",
                principalTable: "TipoEvaluacion",
                principalColumn: "IdTipoEvaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traduccion_Docente_IdDocente",
                table: "Traduccion",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

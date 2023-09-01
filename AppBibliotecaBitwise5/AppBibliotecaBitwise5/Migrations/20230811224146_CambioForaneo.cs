using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppBibliotecaBitwise5.Migrations
{
    /// <inheritdoc />
    public partial class CambioForaneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Generos_GeneroId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_GeneroId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Libro");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdGenero",
                table: "Libro",
                column: "IdGenero");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro",
                column: "IdAutor",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Generos_IdGenero",
                table: "Libro",
                column: "IdGenero",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Generos_IdGenero",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdGenero",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_GeneroId",
                table: "Libro",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Generos_GeneroId",
                table: "Libro",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

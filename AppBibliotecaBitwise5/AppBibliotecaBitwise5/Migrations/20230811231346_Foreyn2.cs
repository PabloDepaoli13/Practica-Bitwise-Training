using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppBibliotecaBitwise5.Migrations
{
    /// <inheritdoc />
    public partial class Foreyn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Libro_LibroId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_LibroId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Comentarios");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdLibro",
                table: "Comentarios",
                column: "IdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Libro_IdLibro",
                table: "Comentarios",
                column: "IdLibro",
                principalTable: "Libro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Libro_IdLibro",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdLibro",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_LibroId",
                table: "Comentarios",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Libro_LibroId",
                table: "Comentarios",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

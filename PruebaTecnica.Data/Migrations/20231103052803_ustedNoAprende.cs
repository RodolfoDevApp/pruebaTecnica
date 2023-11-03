using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Data.Migrations
{
    /// <inheritdoc />
    public partial class ustedNoAprende : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Articulos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Código",
                table: "Articulos",
                newName: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Articulos",
                newName: "Descripción");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Articulos",
                newName: "Código");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Data.Migrations
{
    /// <inheritdoc />
    public partial class segundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Clientes");
        }
    }
}

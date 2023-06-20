using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_MVC_12G.Migrations
{
    public partial class cambiosAtrib : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaPublicacion",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Usuarios",
                newName: "Dni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Usuarios",
                newName: "dni");

            migrationBuilder.AddColumn<int>(
                name: "Seccion",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPublicacion",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

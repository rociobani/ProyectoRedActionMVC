using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_MVC_12G.Migrations
{
    public partial class CambiosAtributosArticuloUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Usuarios_autorId",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "autorId",
                table: "Articulos",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_autorId",
                table: "Articulos",
                newName: "IX_Articulos_AutorId");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Articulos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Usuarios_AutorId",
                table: "Articulos",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Usuarios_AutorId",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Articulos",
                newName: "autorId");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_AutorId",
                table: "Articulos",
                newName: "IX_Articulos_autorId");

            migrationBuilder.AlterColumn<int>(
                name: "autorId",
                table: "Articulos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Usuarios_autorId",
                table: "Articulos",
                column: "autorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamosBiblioteca.Migrations
{
    public partial class AgregandoDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Dell" },
                    { 2, "Hp" },
                    { 3, "Acer" },
                    { 4, "Lenovo" },
                    { 5, "Asus" }
                });

            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "EquipoId", "Codigo", "Descripcion", "Disponibilidad", "MarcaId", "Modelo" },
                values: new object[] { 1, "Dell-01", "Pc", false, 1, "Dell G715" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Codigo",
                table: "Usuarios",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Codigo",
                table: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "EquipoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

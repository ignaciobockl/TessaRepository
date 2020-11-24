using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceTessa.Infraestructure.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ErasedState", "Name" },
                values: new object[,]
                {
                    { 1L, false, "Victoria's Secret" },
                    { 2L, false, "La Perla" },
                    { 3L, false, "Agent Provocateur" },
                    { 4L, false, "Oysho" },
                    { 5L, false, "H&M" },
                    { 6L, false, "E-Lakokette" },
                    { 7L, false, "Botica Lingerie" },
                    { 8L, false, "Pleasurements" },
                    { 9L, false, " Journelle" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ErasedState", "Name" },
                values: new object[,]
                {
                    { 1L, false, "Bikinis" },
                    { 2L, false, "Conjuntos" },
                    { 3L, false, "Enterizas" },
                    { 4L, false, "Bodys" },
                    { 5L, false, "Bombachas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}

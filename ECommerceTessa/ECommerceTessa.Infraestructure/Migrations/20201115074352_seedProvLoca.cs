using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceTessa.Infraestructure.Migrations
{
    public partial class seedProvLoca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Description", "ErasedState" },
                values: new object[,]
                {
                    { 1L, "Jujuy", false },
                    { 21L, "Santa Cruz", false },
                    { 20L, "Chubut", false },
                    { 19L, "Rio Negro", false },
                    { 18L, "Buenos Aires", false },
                    { 17L, "La Pampa", false },
                    { 16L, "Neuquen", false },
                    { 15L, "San Luis", false },
                    { 14L, "Mendoza", false },
                    { 13L, "Santa Fe", false },
                    { 22L, "Tierra Del Fuego", false },
                    { 12L, "Cordoba", false },
                    { 10L, "San Juan", false },
                    { 9L, "Misiones", false },
                    { 8L, "Corrientes", false },
                    { 7L, "Santiago Del Estero", false },
                    { 6L, "Tucuman", false },
                    { 5L, "Catamarca", false },
                    { 4L, "Chaco", false },
                    { 3L, "Formosa", false },
                    { 2L, "Salta", false },
                    { 11L, "La Rioja", false },
                    { 23L, "Entre Rios", false }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "ErasedState", "ProvinceId" },
                values: new object[,]
                {
                    { 1L, "San Salvador De Jujuy", false, 1L },
                    { 24L, "Cruz Del Eje", false, 12L },
                    { 25L, "Santa Fe", false, 13L },
                    { 26L, "Santo Tome", false, 13L },
                    { 27L, "Mendoza", false, 14L },
                    { 28L, "Uspallata", false, 14L },
                    { 29L, "San Luis", false, 15L },
                    { 30L, "Chacabuco", false, 15L },
                    { 31L, "Neuquen", false, 16L },
                    { 32L, "Los Lagos", false, 16L },
                    { 33L, "Santa Rosa", false, 17L },
                    { 34L, "Trenel", false, 17L },
                    { 35L, "Caba", false, 18L },
                    { 36L, "La Plata", false, 18L },
                    { 37L, "Viedma", false, 19L },
                    { 38L, "Las Grutas", false, 19L },
                    { 39L, "Rawson", false, 20L },
                    { 40L, "Sarmiento", false, 20L },
                    { 41L, "Rio Gallegos", false, 21L },
                    { 42L, "Rio Chico", false, 21L },
                    { 23L, "Cordoba", false, 12L },
                    { 22L, "Arauco", false, 11L },
                    { 21L, "La Rioja", false, 11L },
                    { 20L, "Valle Fertil", false, 10L },
                    { 2L, "Humahuaca", false, 1L },
                    { 3L, "Salta", false, 2L },
                    { 4L, "Rosario De La Frontera", false, 2L },
                    { 43L, "Usuahia", false, 2L },
                    { 44L, "Rio Grande", false, 2L },
                    { 5L, "Formosa", false, 3L },
                    { 6L, "Bermejo", false, 3L },
                    { 7L, "Resistencia", false, 4L },
                    { 8L, "Almirante Brown", false, 4L },
                    { 45L, "Parana", false, 23L },
                    { 9L, "San Fernando Del Valle De Catamarca", false, 5L },
                    { 11L, "San Miguel De Tucuman", false, 6L },
                    { 12L, "Yerba Buena", false, 6L },
                    { 13L, "Santiago Del Estero", false, 7L },
                    { 14L, "La Banda", false, 7L },
                    { 15L, "Corrientes", false, 8L },
                    { 16L, "Bella Vista", false, 8L },
                    { 17L, "Posadas", false, 9L },
                    { 18L, "Iguazu", false, 9L },
                    { 19L, "San Juan", false, 10L },
                    { 10L, "Andalgala", false, 5L },
                    { 46L, "Concordia", false, 23L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 23L);
        }
    }
}

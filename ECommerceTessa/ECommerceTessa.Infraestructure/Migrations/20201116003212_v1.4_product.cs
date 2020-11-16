using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceTessa.Infraestructure.Migrations
{
    public partial class v14_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Products_ProductId1",
                table: "ProductPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId1",
                table: "ProductPhotos");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductPhotos");

            migrationBuilder.AddColumn<decimal>(
                name: "Price1",
                table: "Products",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price1",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "ProductId1",
                table: "ProductPhotos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId1",
                table: "ProductPhotos",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Products_ProductId1",
                table: "ProductPhotos",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

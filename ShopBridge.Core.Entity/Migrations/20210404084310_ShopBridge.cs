using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Core.Entity.Migrations
{
    public partial class ShopBridge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    SKUCode = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Local)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName_SKUCode",
                schema: "Inventory",
                table: "Product",
                columns: new[] { "ProductName", "SKUCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Inventory");
        }
    }
}

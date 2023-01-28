using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations
{
    public partial class CreateCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterial_Material_MaterialId",
                table: "ProductMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterial_Products_ProductId",
                table: "ProductMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterial",
                table: "ProductMaterial");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductMaterial",
                newName: "ProductMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMaterial_ProductId",
                table: "ProductMaterials",
                newName: "IX_ProductMaterials_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMaterial_MaterialId",
                table: "ProductMaterials",
                newName: "IX_ProductMaterials_MaterialId");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterials_Material_MaterialId",
                table: "ProductMaterials",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterials_Products_ProductId",
                table: "ProductMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterials_Material_MaterialId",
                table: "ProductMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterials_Products_ProductId",
                table: "ProductMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductMaterials",
                newName: "ProductMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMaterials_ProductId",
                table: "ProductMaterial",
                newName: "IX_ProductMaterial_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMaterials_MaterialId",
                table: "ProductMaterial",
                newName: "IX_ProductMaterial_MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterial",
                table: "ProductMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterial_Material_MaterialId",
                table: "ProductMaterial",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterial_Products_ProductId",
                table: "ProductMaterial",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

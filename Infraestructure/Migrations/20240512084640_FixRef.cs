using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWallet_Products_ProductsId",
                table: "ProductWallet");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductWallet",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWallet_ProductsId",
                table: "ProductWallet",
                newName: "IX_ProductWallet_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWallet_Products_ProductId",
                table: "ProductWallet",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWallet_Products_ProductId",
                table: "ProductWallet");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductWallet",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWallet_ProductId",
                table: "ProductWallet",
                newName: "IX_ProductWallet_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWallet_Products_ProductsId",
                table: "ProductWallet",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

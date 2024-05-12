using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWallet_Products_ProductId",
                table: "ProductWallet");

            migrationBuilder.DropIndex(
                name: "IX_ProductWallet_ProductId",
                table: "ProductWallet");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductWallet");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWallet_ProductsId",
                table: "ProductWallet",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWallet_Products_ProductsId",
                table: "ProductWallet",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWallet_Products_ProductsId",
                table: "ProductWallet");

            migrationBuilder.DropIndex(
                name: "IX_ProductWallet_ProductsId",
                table: "ProductWallet");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductWallet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductWallet_ProductId",
                table: "ProductWallet",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWallet_Products_ProductId",
                table: "ProductWallet",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

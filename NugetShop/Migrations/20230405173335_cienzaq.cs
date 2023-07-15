using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NugetShop.Migrations
{
    public partial class cienzaq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserID",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_CartID",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "CartDetailID",
                table: "CartDetails",
                newName: "UserID");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_UserID",
                table: "CartDetails",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                table: "CartDetails",
                column: "UserID",
                principalTable: "Carts",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_UserID",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CartDetails",
                newName: "CartDetailID");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartID",
                table: "CartDetails",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails",
                column: "CartDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartID",
                table: "CartDetails",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                table: "CartDetails",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

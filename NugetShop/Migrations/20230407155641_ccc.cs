using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NugetShop.Migrations
{
    public partial class ccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_UserID",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "CardID",
                table: "Carts",
                newName: "CartID");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "CartDetails",
                newName: "CartDetailID");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                table: "CartDetails",
                column: "UserID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_CartID",
                table: "Carts",
                column: "CartID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_CartID",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Carts",
                newName: "CardID");

            migrationBuilder.RenameColumn(
                name: "CartDetailID",
                table: "CartDetails",
                newName: "CartID");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart",
                table: "CartDetails",
                column: "UserID",
                principalTable: "Carts",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_UserID",
                table: "Carts",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

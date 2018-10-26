using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadixAPI.Migrations
{
    public partial class GatewayRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreGatewayRule_Stores_StoreId",
                table: "StoreGatewayRule");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreGatewayRule",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_StoreGatewayRule_Stores_StoreId",
                table: "StoreGatewayRule",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreGatewayRule_Stores_StoreId",
                table: "StoreGatewayRule");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreGatewayRule",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreGatewayRule_Stores_StoreId",
                table: "StoreGatewayRule",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

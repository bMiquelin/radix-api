using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadixAPI.Migrations
{
    public partial class TransactionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gateway",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Holder",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastDigits",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NeedAntiFraud",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "Transactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SuccessAntiFraud",
                table: "Transactions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Gateway",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Holder",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastDigits",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "NeedAntiFraud",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SuccessAntiFraud",
                table: "Transactions");
        }
    }
}

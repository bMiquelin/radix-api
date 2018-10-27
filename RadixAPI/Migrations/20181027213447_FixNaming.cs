using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadixAPI.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreGatewayRule");

            migrationBuilder.DropColumn(
                name: "Gateway",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Provider",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StoreProviderRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreId = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(maxLength: 10, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Provider = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProviderRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProviderRules_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProviderRules_StoreId",
                table: "StoreProviderRules",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreProviderRules");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Gateway",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StoreGatewayRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(maxLength: 10, nullable: true),
                    Gateway = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGatewayRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGatewayRule_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreGatewayRule_StoreId",
                table: "StoreGatewayRule",
                column: "StoreId");
        }
    }
}

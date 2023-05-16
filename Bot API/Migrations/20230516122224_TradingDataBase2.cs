using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot_API.Migrations
{
    /// <inheritdoc />
    public partial class TradingDataBase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historiacalData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "historicalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
                    tradingPair = table.Column<int>(type: "integer", nullable: true),
                    timeStamp = table.Column<int>(type: "integer", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
                    volume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicalData", x => x.id);
                    table.ForeignKey(
                        name: "FK_historicalData_tradingPair_tradingPair",
                        column: x => x.tradingPair,
                        principalTable: "tradingPair",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_historicalData_tradingPair",
                table: "historicalData",
                column: "tradingPair");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicalData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "historiacalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    volume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiacalData", x => x.id);
                    table.ForeignKey(
                        name: "FK_historiacalData_tradingPair_tradingPairId",
                        column: x => x.tradingPairId,
                        principalTable: "tradingPair",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historiacalData_tradingPairId",
                table: "historiacalData",
                column: "tradingPairId");
        }
    }
}

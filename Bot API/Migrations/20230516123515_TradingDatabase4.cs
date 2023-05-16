using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot_API.Migrations
{
    /// <inheritdoc />
    public partial class TradingDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicalData");

            migrationBuilder.CreateTable(
                name: "historicalDataList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timestampstart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    timestampend = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datasize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicalDataList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historicaldataitems",
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
                    volume = table.Column<decimal>(type: "numeric", nullable: false),
                    ListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicaldataitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_historicaldataitems_historicalDataList_ListId",
                        column: x => x.ListId,
                        principalTable: "historicalDataList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historicaldataitems_tradingPair_tradingPair",
                        column: x => x.tradingPair,
                        principalTable: "tradingPair",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_historicaldataitems_ListId",
                table: "historicaldataitems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_historicaldataitems_tradingPair",
                table: "historicaldataitems",
                column: "tradingPair");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicaldataitems");

            migrationBuilder.DropTable(
                name: "historicalDataList");

            migrationBuilder.CreateTable(
                name: "historicalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tradingPair = table.Column<int>(type: "integer", nullable: true),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    timeStamp = table.Column<int>(type: "integer", nullable: false),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
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
    }
}

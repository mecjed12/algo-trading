using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot_API.Migrations
{
    /// <inheritdoc />
    public partial class IntialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "echange",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echange", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tradingPair",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coinId = table.Column<int>(type: "integer", nullable: false),
                    quoteCoinId = table.Column<int>(type: "integer", nullable: false),
                    exchangeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradingPair", x => x.id);
                    table.ForeignKey(
                        name: "FK_tradingPair_coins_coinId",
                        column: x => x.coinId,
                        principalTable: "coins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tradingPair_coins_quoteCoinId",
                        column: x => x.quoteCoinId,
                        principalTable: "coins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tradingPair_echange_exchangeId",
                        column: x => x.exchangeId,
                        principalTable: "echange",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historiacalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductId",
                table: "order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tradingPair_coinId",
                table: "tradingPair",
                column: "coinId");

            migrationBuilder.CreateIndex(
                name: "IX_tradingPair_exchangeId",
                table: "tradingPair",
                column: "exchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_tradingPair_quoteCoinId",
                table: "tradingPair",
                column: "quoteCoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historiacalData");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "tradingPair");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "coins");

            migrationBuilder.DropTable(
                name: "echange");
        }
    }
}

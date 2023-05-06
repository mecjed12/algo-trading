using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bot_API.Migrations
{
    /// <inheritdoc />
    public partial class IntialDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tradingPair_echange_exchangeId",
                table: "tradingPair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_echange",
                table: "echange");

            migrationBuilder.RenameTable(
                name: "echange",
                newName: "exchange");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exchange",
                table: "exchange",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tradingPair_exchange_exchangeId",
                table: "tradingPair",
                column: "exchangeId",
                principalTable: "exchange",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tradingPair_exchange_exchangeId",
                table: "tradingPair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exchange",
                table: "exchange");

            migrationBuilder.RenameTable(
                name: "exchange",
                newName: "echange");

            migrationBuilder.AddPrimaryKey(
                name: "PK_echange",
                table: "echange",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tradingPair_echange_exchangeId",
                table: "tradingPair",
                column: "exchangeId",
                principalTable: "echange",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

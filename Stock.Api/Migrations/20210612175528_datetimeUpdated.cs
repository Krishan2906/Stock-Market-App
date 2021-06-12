using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Api.Migrations
{
    public partial class datetimeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockPrices");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "StockPrices",
                newName: "FullDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullDateTime",
                table: "StockPrices",
                newName: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Buy_Stocks_Final_Project.Migrations
{
    public partial class InitialStocksDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    NumberOfTotalStocks = table.Column<int>(nullable: false),
                    StocksSold = table.Column<int>(nullable: false),
                    StockPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StocksBuyer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksBuyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StocksPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    StocksBuyerId = table.Column<int>(nullable: false),
                    NumberOfStocks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocksPayment_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocksPayment_StocksBuyer_StocksBuyerId",
                        column: x => x.StocksBuyerId,
                        principalTable: "StocksBuyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StocksPayment_CompanyId",
                table: "StocksPayment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StocksPayment_StocksBuyerId",
                table: "StocksPayment",
                column: "StocksBuyerId");


            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StocksPayment");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "StocksBuyer");
        }
    }
}

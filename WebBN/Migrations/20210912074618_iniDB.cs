using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBN.Migrations
{
    public partial class iniDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetupFees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupFees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TansactionLogs",
                columns: table => new
                {
                    TranID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Types = table.Column<int>(type: "int", nullable: false),
                    IBAN_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TansactionLogs", x => x.TranID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit_Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetupFees");

            migrationBuilder.DropTable(
                name: "TansactionLogs");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}

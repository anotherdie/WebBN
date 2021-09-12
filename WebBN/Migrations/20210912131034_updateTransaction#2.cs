using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBN.Migrations
{
    public partial class updateTransaction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountAfterFee",
                table: "TansactionLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "TansactionLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountAfterFee",
                table: "TansactionLogs");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "TansactionLogs");
        }
    }
}

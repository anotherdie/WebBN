using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBN.Migrations
{
    public partial class updateTransLog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "TansactionLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ToIBAN_No",
                table: "TansactionLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TansactionLogs");

            migrationBuilder.DropColumn(
                name: "ToIBAN_No",
                table: "TansactionLogs");
        }
    }
}

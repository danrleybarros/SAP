using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlterTableLogDetail_Line : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Test",
                schema: "JsdnBill",
                table: "LogDetail");

            migrationBuilder.AddColumn<string>(
                name: "Line",
                schema: "JsdnBill",
                table: "LogDetail",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line",
                schema: "JsdnBill",
                table: "LogDetail");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                schema: "JsdnBill",
                table: "LogDetail",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                column: "InvoiceNumber");
        }
    }
}

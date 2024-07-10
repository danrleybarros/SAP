using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlterTableCustomersChangeNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyAcronym",
                schema: "JsdnBill",
                table: "Customer",
                newName: "CustomerCode");

            migrationBuilder.RenameColumn(
                name: "CompanyAcronym",
                schema: "JsdnBill",
                table: "BillFeed",
                newName: "CustomerCode");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCodeName",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCode",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                schema: "JsdnBill",
                table: "Customer",
                newName: "CompanyAcronym");

            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                schema: "JsdnBill",
                table: "BillFeed",
                newName: "CompanyAcronym");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCodeName",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCode",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}

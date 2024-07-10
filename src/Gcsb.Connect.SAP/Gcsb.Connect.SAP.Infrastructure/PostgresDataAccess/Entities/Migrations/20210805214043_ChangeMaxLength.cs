using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class ChangeMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountDeb",
                schema: "JsdnBill",
                table: "CreditGrantedFinancialAccount",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCred",
                schema: "JsdnBill",
                table: "CreditGrantedFinancialAccount",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountDeb",
                schema: "JsdnBill",
                table: "CreditGrantedFinancialAccount",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCred",
                schema: "JsdnBill",
                table: "CreditGrantedFinancialAccount",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }
    }
}

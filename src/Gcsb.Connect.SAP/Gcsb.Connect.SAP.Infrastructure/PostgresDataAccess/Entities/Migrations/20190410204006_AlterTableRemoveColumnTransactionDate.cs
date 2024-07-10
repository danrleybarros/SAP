using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlterTableRemoveColumnTransactionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                schema: "JsdnBill",
                table: "PaymentFeed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionDate",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddStoreToInterestAndFineFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Store",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                nullable: false,
                defaultValue: "TBRA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Store",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");
        }
    }
}

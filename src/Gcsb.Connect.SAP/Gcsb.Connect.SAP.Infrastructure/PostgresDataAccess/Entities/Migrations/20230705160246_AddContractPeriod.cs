using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddContractPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractPeriod",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractPeriod",
                schema: "JsdnBill",
                table: "DeferralOffer");
        }
    }
}

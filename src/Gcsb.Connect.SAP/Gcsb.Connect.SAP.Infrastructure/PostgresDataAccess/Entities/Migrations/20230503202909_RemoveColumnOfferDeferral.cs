using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveColumnOfferDeferral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferDeferral",
                schema: "JsdnBill",
                table: "DeferralOffer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferDeferral",
                schema: "JsdnBill",
                table: "DeferralOffer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

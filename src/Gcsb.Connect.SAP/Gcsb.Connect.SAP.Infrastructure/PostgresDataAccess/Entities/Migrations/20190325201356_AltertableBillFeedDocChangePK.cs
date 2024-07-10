using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AltertableBillFeedDocChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_BillFeed_Sequence",
                schema: "JsdnBill",
                table: "BillFeed",
                column: "Sequence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_BillFeed_Sequence",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}

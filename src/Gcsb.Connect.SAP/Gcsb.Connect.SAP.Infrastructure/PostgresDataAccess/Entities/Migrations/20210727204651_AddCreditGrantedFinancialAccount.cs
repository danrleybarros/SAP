using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddCreditGrantedFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditGrantedFinancialAccount",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StoreAcronym = table.Column<string>(nullable: false),
                    CreditGrantedAJU = table.Column<string>(maxLength: 15, nullable: false),
                    AccountingAccountDeb = table.Column<string>(maxLength: 8, nullable: false),
                    AccountingAccountCred = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditGrantedFinancialAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditGrantedFinancialAccount",
                schema: "JsdnBill");
        }
    }
}

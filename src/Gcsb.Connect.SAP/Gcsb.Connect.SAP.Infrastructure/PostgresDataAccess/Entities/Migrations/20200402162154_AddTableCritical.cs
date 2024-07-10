using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddTableCritical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Critical",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankCode = table.Column<string>(nullable: false),
                    InvoiceAmount = table.Column<decimal>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    InclusionDate = table.Column<DateTime>(nullable: false),
                    IdFile = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Critical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Critical_File_IdFile",
                        column: x => x.IdFile,
                        principalSchema: "JsdnBill",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Critical_IdFile",
                schema: "JsdnBill",
                table: "Critical",
                column: "IdFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Critical",
                schema: "JsdnBill");
        }
    }
}

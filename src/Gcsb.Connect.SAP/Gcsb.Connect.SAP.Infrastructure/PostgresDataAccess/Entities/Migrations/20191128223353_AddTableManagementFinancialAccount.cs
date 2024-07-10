using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddTableManagementFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingAccount",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Credit = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    Debit = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billet",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AccountingAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billet_AccountingAccount_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "AccountingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AccountingAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_AccountingAccount_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "AccountingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Critic",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AccountingAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Critic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Critic_AccountingAccount_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "AccountingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AccountingAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_AccountingAccount_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "AccountingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unassigned",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AccountingAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unassigned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unassigned_AccountingAccount_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalSchema: "JsdnBill",
                        principalTable: "AccountingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARR",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BilletId = table.Column<Guid>(nullable: false),
                    CreditCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ARR_Billet_BilletId",
                        column: x => x.BilletId,
                        principalSchema: "JsdnBill",
                        principalTable: "Billet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ARR_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "JsdnBill",
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementFinancialAccount",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ARRId = table.Column<Guid>(nullable: false),
                    UnassignedId = table.Column<Guid>(nullable: false),
                    CriticId = table.Column<Guid>(nullable: false),
                    TransferId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementFinancialAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementFinancialAccount_ARR_ARRId",
                        column: x => x.ARRId,
                        principalSchema: "JsdnBill",
                        principalTable: "ARR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementFinancialAccount_Critic_CriticId",
                        column: x => x.CriticId,
                        principalSchema: "JsdnBill",
                        principalTable: "Critic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementFinancialAccount_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalSchema: "JsdnBill",
                        principalTable: "Transfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementFinancialAccount_Unassigned_UnassignedId",
                        column: x => x.UnassignedId,
                        principalSchema: "JsdnBill",
                        principalTable: "Unassigned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARR_BilletId",
                schema: "JsdnBill",
                table: "ARR",
                column: "BilletId");

            migrationBuilder.CreateIndex(
                name: "IX_ARR_CreditCardId",
                schema: "JsdnBill",
                table: "ARR",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Billet_AccountingAccountId",
                schema: "JsdnBill",
                table: "Billet",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_AccountingAccountId",
                schema: "JsdnBill",
                table: "CreditCard",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Critic_AccountingAccountId",
                schema: "JsdnBill",
                table: "Critic",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementFinancialAccount_ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "ARRId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementFinancialAccount_CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "CriticId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementFinancialAccount_TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementFinancialAccount_UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "UnassignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_AccountingAccountId",
                schema: "JsdnBill",
                table: "Transfer",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Unassigned_AccountingAccountId",
                schema: "JsdnBill",
                table: "Unassigned",
                column: "AccountingAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagementFinancialAccount",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "ARR",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Critic",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Transfer",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Unassigned",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "Billet",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "JsdnBill");

            migrationBuilder.DropTable(
                name: "AccountingAccount",
                schema: "JsdnBill");
        }
    }
}

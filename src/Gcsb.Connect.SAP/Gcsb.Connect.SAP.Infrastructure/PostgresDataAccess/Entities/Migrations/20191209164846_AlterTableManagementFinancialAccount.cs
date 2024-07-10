using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlterTableManagementFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementFinancialAccount_ARR_ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagementFinancialAccount_Critic_CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagementFinancialAccount_Transfer_TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagementFinancialAccount_Unassigned_UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

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

            migrationBuilder.DropIndex(
                name: "IX_ManagementFinancialAccount_ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropIndex(
                name: "IX_ManagementFinancialAccount_CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropIndex(
                name: "IX_ManagementFinancialAccount_TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropIndex(
                name: "IX_ManagementFinancialAccount_UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.AddColumn<string>(
                name: "FinancialAccountBillet",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinancialAccountCreditCard",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinancialAccountCritic",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinancialAccountTransferred",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinancialAccountUnassigned",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountBilletCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountBilletDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountCreditCardCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountCreditCardDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountCriticCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountCriticDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountTransferCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountTransferDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountUnassignedCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountingAccountUnassignedDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialAccountBillet",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FinancialAccountCreditCard",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FinancialAccountCritic",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FinancialAccountTransferred",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FinancialAccountUnassigned",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountBilletCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountBilletDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountCreditCardCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountCreditCardDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountCriticCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountCriticDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountTransferCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountTransferDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountUnassignedCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.DropColumn(
                name: "AccountingAccountUnassignedDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount");

            migrationBuilder.AddColumn<Guid>(
                name: "ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                    AccountingAccountId = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
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
                    AccountingAccountId = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
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
                    AccountingAccountId = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
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
                    AccountingAccountId = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
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
                    AccountingAccountId = table.Column<Guid>(nullable: false),
                    FinancialAccount = table.Column<string>(type: "varchar", maxLength: 15, nullable: false)
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
                name: "IX_Transfer_AccountingAccountId",
                schema: "JsdnBill",
                table: "Transfer",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Unassigned_AccountingAccountId",
                schema: "JsdnBill",
                table: "Unassigned",
                column: "AccountingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementFinancialAccount_ARR_ARRId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "ARRId",
                principalSchema: "JsdnBill",
                principalTable: "ARR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementFinancialAccount_Critic_CriticId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "CriticId",
                principalSchema: "JsdnBill",
                principalTable: "Critic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementFinancialAccount_Transfer_TransferId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "TransferId",
                principalSchema: "JsdnBill",
                principalTable: "Transfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementFinancialAccount_Unassigned_UnassignedId",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                column: "UnassignedId",
                principalSchema: "JsdnBill",
                principalTable: "Unassigned",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

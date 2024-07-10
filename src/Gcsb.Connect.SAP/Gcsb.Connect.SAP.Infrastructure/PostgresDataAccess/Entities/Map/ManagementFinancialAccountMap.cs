
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    class ManagementFinancialAccountMap : IEntityTypeConfiguration<ManagementFinancialAccount.ManagementFinancialAccount>
    {
        public void Configure(EntityTypeBuilder<ManagementFinancialAccount.ManagementFinancialAccount> builder)
        {
            builder.ToTable("ManagementFinancialAccount", "JsdnBill");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.StoreType).HasDefaultValue(StoreType.TBRA);

            builder.OwnsOne(c => c.ARR, arr => arr.OwnsOne(b => b.Boleto, boleto => boleto.OwnsOne(c => c.AccountingAccount, accounting =>
            {
                boleto.Property(c => c.FinancialAccount)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasColumnName("FinancialAccountBoleto");

                accounting.Property(c => c.Credit)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasColumnName("AccountingAccountBoletoCredit");

                accounting.Property(c => c.Debit)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasColumnName("AccountingAccountBoletoDebit");
            })));

            builder.OwnsOne(c => c.ARR, arr => arr.OwnsOne(b => b.CreditCard, creditCard => creditCard.OwnsOne(c => c.AccountingAccount, accounting =>
            {
                creditCard.Property(c => c.FinancialAccount)
                   .IsRequired()
                   .HasColumnType("varchar(15)")
                   .HasColumnName("FinancialAccountCreditCard");

                accounting.Property(c => c.Credit)
                   .IsRequired()
                   .HasColumnType("varchar(15)")
                   .HasColumnName("AccountingAccountCreditCardCredit");

                accounting.Property(c => c.Debit)
                   .IsRequired()
                   .HasColumnType("varchar(15)")
                   .HasColumnName("AccountingAccountCreditCardDebit");
            })));

            builder.OwnsOne(c => c.Unassigned, unassigned => unassigned.OwnsOne(c => c.AccountingAccount, accounting =>
            {
                unassigned.Property(c => c.FinancialAccount)
                   .IsRequired()
                   .HasColumnType("varchar(15)")
                   .HasColumnName("FinancialAccountUnassigned");

                accounting.Property(c => c.Credit)
                   .IsRequired()
                   .HasColumnType("varchar(15)")
                   .HasColumnName("AccountingAccountUnassignedCredit");

                accounting.Property(c => c.Debit)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("AccountingAccountUnassignedDebit");

            }));

            builder.OwnsOne(c => c.Critic, critic => critic.OwnsOne(c => c.AccountingAccount, accounting =>
            {
                critic.Property(c => c.FinancialAccount)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("FinancialAccountCritic");

                accounting.Property(c => c.Credit)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("AccountingAccountCriticCredit");

                accounting.Property(c => c.Debit)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("AccountingAccountCriticDebit");

            }));

            builder.OwnsOne(c => c.Transfer, transfer => transfer.OwnsOne(c => c.AccountingAccount, accounting =>
            {
                transfer.Property(c => c.FinancialAccount)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("FinancialAccountTransferred");

                accounting.Property(c => c.Credit)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("AccountingAccountTransferCredit");

                accounting.Property(c => c.Debit)
                  .IsRequired()
                  .HasColumnType("varchar(15)")
                  .HasColumnName("AccountingAccountTransferDebit");

            }));
        }
    }
}

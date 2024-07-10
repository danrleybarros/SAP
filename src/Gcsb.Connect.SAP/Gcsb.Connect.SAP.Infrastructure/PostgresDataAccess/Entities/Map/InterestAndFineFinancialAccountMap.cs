using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class InterestAndFineFinancialAccountMap : IEntityTypeConfiguration<InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>
    {
        public void Configure(EntityTypeBuilder<InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> builder)
        {
            builder.ToTable("InterestAndFineFinancialAccount", "JsdnBill");

            builder.HasKey(d => d.Id);

            builder.Property(c => c.Store).HasDefaultValue(Domain.JSDN.Stores.StoreType.TBRA).HasConversion<string>();

            builder.OwnsOne(i => i.Interest, interest =>
            {
                interest.Property(c => c.FinancialAccount).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestFinancialAccount");
            });

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.InterestOrFine, interestOrFine => 
            {
                interestOrFine.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestCredit");
                interestOrFine.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.UnpaidInvoice, unpaidInvoice =>
            {
                unpaidInvoice.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestUnpaidInvoiceCredit");
                unpaidInvoice.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestUnpaidInvoiceDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.PaidInvoice, paidInvoice =>
            {
                paidInvoice.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestPaidInvoiceCredit");
                paidInvoice.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestPaidInvoiceDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.CycleEstimate, cycleEstimate =>
            {
                cycleEstimate.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestCycleEstimateCredit");
                cycleEstimate.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("InterestCycleEstimateDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine =>
            { 
                fine.Property(c => c.FinancialAccount).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineFinancialAccount");
            });
            
            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.InterestOrFine, interestOrFine =>
            {
                interestOrFine.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineCredit");
                interestOrFine.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.UnpaidInvoice, unpaidInvoice =>
            {
                unpaidInvoice.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineUnpaidInvoiceCredit");
                unpaidInvoice.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineUnpaidInvoiceDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.PaidInvoice, paidInvoice =>
            {
                paidInvoice.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FinePaidInvoiceCredit");
                paidInvoice.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FinePaidInvoiceDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.CycleEstimate, cycleEstimate =>
            {
                cycleEstimate.Property(c => c.Credit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineCycleEstimateCredit");
                cycleEstimate.Property(c => c.Debit).IsRequired().HasColumnType("varchar(15)").HasColumnName("FineCycleEstimateDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest =>
            {
                interest.Property(c => c.BilledCounterchargeChargeback).HasColumnType("varchar(15)").HasColumnName("InterestBilledCounterchargeChargeback");
            });

            builder.OwnsOne(i => i.Interest, interest =>
            {
                interest.Property(c => c.GrantedDebit).HasColumnType("varchar(15)").HasColumnName("InterestGrantedDebit");
            });

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.ChargebackFutureCreditUnusedValue, chargebackFutureCreditUnusedValue =>
            {
                chargebackFutureCreditUnusedValue.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackFutureCreditUnusedValueCredit");
                chargebackFutureCreditUnusedValue.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackFutureCreditUnusedValueDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.ChargebackFutureCreditUsedValue, chargebackFutureCreditUsedValue =>
            {
                chargebackFutureCreditUsedValue.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackFutureCreditUsedValueCredit");
                chargebackFutureCreditUsedValue.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackFutureCreditUsedValueDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.ChargebackRectifiedBoleto, chargebackRectifiedBoleto =>
            {
                chargebackRectifiedBoleto.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackRectifiedBoletoCredit");
                chargebackRectifiedBoleto.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("InterestChargebackRectifiedBoletoDebit");
            }));

            builder.OwnsOne(i => i.Interest, interest => interest.OwnsOne(b => b.GrantedDebitAccounting, grantedDebitAccounting =>
            {
                grantedDebitAccounting.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("InterestGrantedDebitAccountingCredit");
                grantedDebitAccounting.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("InterestGrantedDebitAccountingDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine =>
            {
                fine.Property(c => c.BilledCounterchargeChargeback).HasColumnType("varchar(15)").HasColumnName("FineBilledCounterchargeChargeback");
            });

            builder.OwnsOne(i => i.Fine, fine =>
            {
                fine.Property(c => c.GrantedDebit).HasColumnType("varchar(15)").HasColumnName("FineGrantedDebit");
            });

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.ChargebackFutureCreditUnusedValue, chargebackFutureCreditUnusedValue =>
            {
                chargebackFutureCreditUnusedValue.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("FineChargebackFutureCreditUnusedValueCredit");
                chargebackFutureCreditUnusedValue.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("FineChargebackFutureCreditUnusedValueDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.ChargebackFutureCreditUsedValue, chargebackFutureCreditUsedValue =>
            {
                chargebackFutureCreditUsedValue.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("FineChargebackFutureCreditUsedValueCredit");
                chargebackFutureCreditUsedValue.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("FineChargebackFutureCreditUsedValueDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.ChargebackRectifiedBoleto, chargebackRectifiedBoleto =>
            {
                chargebackRectifiedBoleto.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("FineChargebackRectifiedBoletoCredit");
                chargebackRectifiedBoleto.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("FineChargebackRectifiedBoletoDebit");
            }));

            builder.OwnsOne(i => i.Fine, fine => fine.OwnsOne(b => b.GrantedDebitAccounting, grantedDebitAccounting =>
            {
                grantedDebitAccounting.Property(c => c.Credit).HasColumnType("varchar(15)").HasColumnName("FineGrantedDebitAccountingCredit");
                grantedDebitAccounting.Property(c => c.Debit).HasColumnType("varchar(15)").HasColumnName("FineGrantedDebitAccountingDebit");
            }));
        }
    }
}

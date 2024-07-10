using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map.Jsdn
{
    public class PaymentReportMap : IEntityTypeConfiguration<PaymentReport>
    {
        public void Configure(EntityTypeBuilder<PaymentReport> builder)
        {
            var schema = Environment.GetEnvironmentVariable("JSDN_SCHEMA");

            builder.ToView("payment_reports", schema);

            builder.Property(e => e.ServiceCode)
                .HasColumnName("service_code")
                .HasMaxLength(256);

            builder.Property(e => e.ServiceName)
                .HasColumnName("service_name")
                .HasMaxLength(256);

            builder.Property(e => e.StoreAcronym)
                .HasColumnName("store_acronym")
                .HasMaxLength(256);

            builder.Property(e => e.ProviderCompanyAcronym)
                .HasColumnName("company_provider_acronym")
                .HasMaxLength(256);

            builder.Property(e => e.CustomerCode)
                .HasColumnName("customer_code")
                .HasMaxLength(256);

            builder.Property(e => e.InvoiceNumber)
                .HasColumnName("invoice_number")
                .HasMaxLength(256);

            builder.Property(e => e.BankCode)
                .HasColumnName("bank_code")
                .HasMaxLength(60);

            builder.Property(e => e.PaymentDate)
                .HasColumnName("payment_date");

            builder.Property(e => e.PaymentValue)
                .HasColumnName("payment_value");

            builder.Property(e => e.TotalPaymentValue)
                .HasColumnName("total_payment_value");

            builder.HasNoKey();
        }
    }
}

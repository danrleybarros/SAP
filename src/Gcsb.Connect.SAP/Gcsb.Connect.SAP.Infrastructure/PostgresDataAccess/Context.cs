using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess
{
    public class Context : DbContext
    {
        public DbSet<Entities.FinancialAccount> FinancialAccount { get; set; }
        public DbSet<Entities.BillFeedSplit.Customer> Customer { get; set; }
        public DbSet<Entities.BillFeedSplit.Invoice> Invoice { get; set; }
        public DbSet<Entities.BillFeedSplit.ServiceInvoice> ServiceInvoice { get; set; }
        public DbSet<Entities.PaymentCreditCard> PaymentFeedCreditCard { get; set; }
        public DbSet<Entities.PaymentBoleto> PaymentBoleto { get; set; }
        public DbSet<Entities.File> File { get; set; }
        public DbSet<Entities.Log> Log { get; set; }
        public DbSet<Entities.LogDetail> LogDetail { get; set; }
        public DbSet<Entities.BillFeedDoc> BillFeed { get; set; }
        public DbSet<Entities.ReturnNF> ReturnNF { get; set; }
        public DbSet<Entities.FinancialAccountDate> FinancialAccountDate { get; set; }
        public DbSet<Entities.ManagementFinancialAccount.ManagementFinancialAccount> ManagementFinancialAccount { get; set; }
        public DbSet<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> InterestAndFineFinancialAccount { get; set; }
        public DbSet<Entities.Pay.Critical> Critica { get; set; }       
        public DbSet<CreditGrantedFinancialAccount> CreditGrantedFinancialAccount { get; set; }        
        public DbSet<Entities.Upload> Upload { get; set; }
        public DbSet<Entities.InterfaceProgress> InterfaceProgress { get; set; }
        public DbSet<Entities.StatusActivationService> StatusActivationService { get; set; }
        public DbSet<Entities.Deferral.DeferralOffer> DeferralFinancial { get; set; }
        public DbSet<Entities.Deferral.DeferralHistory> DeferralHistory { get; set; }

        public Context()
        {
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = Environment.GetEnvironmentVariable("SAP_INT_CONN") ?? Environment.GetEnvironmentVariable("DBCONN");

            if (conn != null)
            {
                optionsBuilder.UseNpgsql(conn, npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "JsdnBill");                  
                });

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("SapInMemory");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entities.Map.FinancialAccountMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.CustomerMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.InvoiceMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.ServiceInvoiceMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.PaymentFeedDocMap());
            modelBuilder.Entity<PaymentCreditCard>().HasBaseType<PaymentFeedDoc>();
            modelBuilder.Entity<PaymentBoleto>().HasBaseType<PaymentFeedDoc>();
            modelBuilder.ApplyConfiguration(new Entities.Map.FileMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.LogMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.LogDetailMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.BillFeedDocMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.ReturnNFMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.FinancialAccountDateMap());         
            modelBuilder.ApplyConfiguration(new Entities.Map.ManagementFinancialAccountMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.InterestAndFineFinancialAccountMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.Pay.CriticalMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.CreditGrantedFinancialAccountMap());            
            modelBuilder.ApplyConfiguration(new Entities.Map.UploadMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.InterfaceProgressMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.StatusActivationServiceMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.DeferralOfferMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.DeferralHistoryMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}

using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess
{
    public class JsdnContext : DbContext
    {
        public virtual DbSet<CounterchargeDispute> CounterchargeDispute { get; set; }
        public virtual DbSet<PaymentReport> PaymentReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("JSDN_CONN"), npgsqlOptionsAction: option =>
            {
                option.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entities.Map.Jsdn.CounterchargeDisputeMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.Jsdn.PaymentReportMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

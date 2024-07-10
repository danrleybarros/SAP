using Gcsb.Connect.SAP.Domain.DigitalCertificate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess
{
    public class DigitalCertificateContext : DbContext
    {
        public DbSet<CertificateStatusLicense> CertificateStatusLicense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("SAP_INT_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SAP_INT_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "JsdnBill");
                });
            }           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CertificateStatusLicense>(entity =>
            {
                entity.ToView("vw_certificate_status_license", "DigitalCertificate");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

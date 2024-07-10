using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.DigitalCertificate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class DigitalCertificateRepository : IDigitalCertificateRepository
    {
        public List<CertificateStatusLicense> GetCerficateStatusLicense(List<string> orderNumbers)
        {
            using var context = new DigitalCertificateContext();
            return context.CertificateStatusLicense
                .Where(w => orderNumbers.Contains(w.OrderNumber))
                .AsNoTracking()
                .ToList();
        }
    }
}

using Gcsb.Connect.SAP.Domain.DigitalCertificate;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IDigitalCertificateRepository
    {
        List<CertificateStatusLicense> GetCerficateStatusLicense(List<string> orderNumbers);
    }
}

using Gcsb.Connect.SAP.Domain.DigitalCertificate;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.DigitalCertificate
{
    public class CertificateStatusLicenseBuilder
    {
        public string OfferCode;
        public string ServiceCode;
        public string OrderNumber;
        public int LicenseNum { get; private set; }
        public DateTime OrderDate;
        public string Status;

        public static CertificateStatusLicenseBuilder New()
        {
            return new CertificateStatusLicenseBuilder
            {
                OfferCode = "SerasaCertificadoDigitalE-CPF",
                ServiceCode = "SerasaCertificadoDigital",
                OrderNumber = "4012114",
                LicenseNum = 6,
                OrderDate = DateTime.Now,
                Status = "Aguardando Emissão"
            };
        }

        public CertificateStatusLicenseBuilder WithOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public CertificateStatusLicenseBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public CertificateStatusLicenseBuilder WithOrderNumber(string orderNumber)
        {
            OrderNumber = orderNumber;
            return this;
        }

        public CertificateStatusLicenseBuilder WithLicenseNum(int licenseNum)
        {
            LicenseNum = licenseNum;
            return this;
        }

        public CertificateStatusLicenseBuilder WithOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
            return this;
        }

        public CertificateStatusLicenseBuilder WithStatus(string status)
        {
            Status = status;
            return this;
        }

        public CertificateStatusLicense Build()
         => new CertificateStatusLicense(OfferCode,ServiceCode,OrderNumber,LicenseNum,OrderDate,Status);
        
    }
}

using System;

namespace Gcsb.Connect.SAP.Domain.DigitalCertificate
{
    public class CertificateStatusLicense
    {       
        public string OfferCode { get; private set; }
        public string ServiceCode { get; private set; }
        public string OrderNumber { get; private set; }
        public int LicenseNum { get; private set; }
        public DateTime OrderDate { get; private set; }      
        public string Status { get; private set; }    

        public CertificateStatusLicense(string offerCode, string serviceCode, string orderNumber, int licenseNum, DateTime orderDate, string status)
        {
            OfferCode = offerCode;
            ServiceCode = serviceCode;
            OrderNumber = orderNumber;
            LicenseNum = licenseNum;
            OrderDate = orderDate;
            Status = status;
        }
    }
}
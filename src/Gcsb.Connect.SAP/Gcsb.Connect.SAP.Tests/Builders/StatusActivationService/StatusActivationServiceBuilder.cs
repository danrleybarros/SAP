using System;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService.Enum;

namespace Gcsb.Connect.SAP.Tests.Builders.StatusActivationService
{
    public class StatusActivationServiceBuilder
    {
        public Guid Id;
        public string OrderNumber;
        public string CustomerCode;
        public string ServiceCode;
        public string OfferCode;
        public DateTime PurchaseDate;
        public ActivationTypeEnum ActivationStatus;
        public DateTime? ActivationDate;
        public DateTime? ExpirationDate;


        public static StatusActivationServiceBuilder New()
        {
            return new StatusActivationServiceBuilder
            {
                Id = Guid.NewGuid(),
                OrderNumber = "445423465",
                CustomerCode = "400778900",
                ServiceCode = "34354566",
                OfferCode = "OFFICE",
                PurchaseDate = DateTime.UtcNow,
                ActivationStatus = ActivationTypeEnum.Activated,
                ActivationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow
            };
        }

        public Domain.Deferral.StatusActivationService.StatusActivationService Build()
        {
            var domain = new Domain.Deferral.StatusActivationService.StatusActivationService(Id, OrderNumber, CustomerCode, ServiceCode, OfferCode, PurchaseDate, ActivationStatus);
            domain.ActivateService(ActivationDate.Value, ExpirationDate.Value);

            return domain;            
        }



    }
}

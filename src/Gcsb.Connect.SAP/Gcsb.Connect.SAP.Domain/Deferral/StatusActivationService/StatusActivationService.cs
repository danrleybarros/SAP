using System;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService.Enum;

namespace Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService
{
    public class StatusActivationService : IEntity
    {
        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; }
        public string CustomerCode { get; private set; }
        public string ServiceCode { get; private set; }
        public string OfferCode { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public ActivationTypeEnum ActivationStatus { get; private set; }
        public DateTime? ActivationDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }

        public StatusActivationService(Guid id, string orderNumber, string customerCode, string serviceCode, string offerCode, DateTime purchaseDate, ActivationTypeEnum activationStatus)
        {
            Id = id;
            OrderNumber = orderNumber;
            CustomerCode = customerCode;
            ServiceCode = serviceCode;
            OfferCode = offerCode;
            PurchaseDate = purchaseDate;
            ActivationStatus = activationStatus;           
        }

        public void ActivateService(DateTime activationDate, DateTime expirationDate)
        {
            ActivationDate = activationDate;
            ExpirationDate = expirationDate;
        
        }
    }
}

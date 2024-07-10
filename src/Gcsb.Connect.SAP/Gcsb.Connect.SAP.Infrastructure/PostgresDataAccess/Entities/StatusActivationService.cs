using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService.Enum;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class StatusActivationService
    {
       
        public Guid Id { get;  set; }      
        public string OrderNumber { get;  set; }       
        public string CustomerCode { get;  set; }      
        public string ServiceCode { get;  set; }        
        public string OfferCode { get;  set; }       
        public DateTime PurchaseDate { get;  set; }       
        public ActivationTypeEnum ActivationStatus { get;  set; }
        public DateTime? ActivationDate { get;  set; }
        public DateTime? ExpirationDate { get; set; }
    }
}

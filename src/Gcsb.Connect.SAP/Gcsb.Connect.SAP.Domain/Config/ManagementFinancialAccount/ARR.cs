using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class ARR
    {     
        [Required]
        public Boleto Boleto { get;private set; }

        [Required]
        public CreditCard CreditCard { get; private set; }

        public ARR(Boleto boleto, CreditCard creditCard)
        {           
            Boleto = boleto;
            CreditCard = creditCard;
        }
    }
}

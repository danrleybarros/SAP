using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Update
{
    public sealed class ManagementFinancialUpdateRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Boleto Boleto { get; set; }

        [Required]
        public CreditCard CreditCard { get; set; }

        [Required]
        public Unassigned Unassigned { get; set; }

        [Required]
        public Critic Critic { get; set; }

        [Required]
        public Transferred Transferred { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreType { get; set; }

        public Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount Map()
        {
            var model = new Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount
                (
                  Id,
                  new Domain.Config.ManagementFinancialAccount.ARR(Boleto.Map(), CreditCard.Map()),
                  new Domain.Config.ManagementFinancialAccount.Unassigned(Unassigned.FinancialAccount, Unassigned.Map()),
                  new Domain.Config.ManagementFinancialAccount.Critic(Critic.FinancialAccount, Critic.Map()),
                  new Domain.Config.ManagementFinancialAccount.Transferred(Transferred.FinancialAccount, Transferred.Map()),
                  StoreType = StoreType
                 );

            return model;
        }
    }
}

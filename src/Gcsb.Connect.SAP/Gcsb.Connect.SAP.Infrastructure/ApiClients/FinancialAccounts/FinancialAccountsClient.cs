using System;
using System.Collections.Generic;
using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Newtonsoft.Json;
using RestSharp;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using CreditGranted = Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using InterestAndFine = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.FinancialAccounts
{
    public class FinancialAccountsClient : IFinancialAccountsClient
    {
        private readonly IService service;
        private readonly IMapper mapper;

        public FinancialAccountsClient(IService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public AccountDetailsByServiceDto GetAccountDetailsByService(List<string> services, List<string> interfaceTypes)
        {
            var apiUrl = Environment.GetEnvironmentVariable("FINANCIAL_ACCOUNTS_API");
            var request = new RestRequest("/api/FinancialAccounts/GetAccountDetailsByService", Method.POST);

            var body = new AccountDetailsByServiceRequest(services, interfaceTypes);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());
            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);

            var response = service.Execute<AccountDetailsByServiceDto>(apiUrl, request);

            return response;
        }

        public List<ManagementFinancialAccountDto> GetAllManagementFinancialAccount()
        {
            var apiUrl = Environment.GetEnvironmentVariable("FINANCIAL_ACCOUNTS_API");
            var request = new RestRequest("/api/ManagementFinancialAccount/GetAll", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());

            var response = service.Execute<List<ManagementFinancialAccountDto>>(apiUrl, request);

            return response;
        }

        public List<InterestAndFine::InterestAndFineFinancialAccount> GetAllInterestAndFineFinancialAccount()
        {
            var apiUrl = Environment.GetEnvironmentVariable("FINANCIAL_ACCOUNTS_API");
            var request = new RestRequest("/api/InterestAndFineFinancialAccount/GetAll", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());

            var response = service.Execute<List<InterestAndFineFinancialAccountDto>>(apiUrl, request);

            var list = new List<InterestAndFine::InterestAndFineFinancialAccount>();

            list.AddRange(response
                .Select(s => new InterestAndFine::InterestAndFineFinancialAccount(
                    s.Id,
                    Domain.Util.ToEnum<StoreType>(s.FinancialAccount.StoreAcronym),
                    new InterestAndFine::Account(
                        s.FinancialAccount.Interest.FinancialAccount,
                        s.FinancialAccount.Interest.BilledCounterchargeChargeback,
                        s.FinancialAccount.Interest.GrantedDebit,
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.InterestOrFine.Credit, s.FinancialAccount.Interest.InterestOrFine.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.UnpaidInvoice.Credit, s.FinancialAccount.Interest.UnpaidInvoice.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.PaidInvoice.Credit, s.FinancialAccount.Interest.PaidInvoice.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.CycleEstimate.Credit, s.FinancialAccount.Interest.CycleEstimate.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Credit, s.FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Credit, s.FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.ChargebackRectifiedBoleto.Credit, s.FinancialAccount.Interest.ChargebackRectifiedBoleto.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Interest.GrantedDebitAccounting.Credit, s.FinancialAccount.Interest.GrantedDebitAccounting.Debit)),
                    new InterestAndFine::Account(
                        s.FinancialAccount.Fine.FinancialAccount,
                        s.FinancialAccount.Fine.BilledCounterchargeChargeback,
                        s.FinancialAccount.Fine.GrantedDebit,
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.InterestOrFine.Credit, s.FinancialAccount.Fine.InterestOrFine.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.UnpaidInvoice.Credit, s.FinancialAccount.Fine.UnpaidInvoice.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.PaidInvoice.Credit, s.FinancialAccount.Fine.PaidInvoice.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.CycleEstimate.Credit, s.FinancialAccount.Fine.CycleEstimate.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Credit, s.FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Credit, s.FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.ChargebackRectifiedBoleto.Credit, s.FinancialAccount.Fine.ChargebackRectifiedBoleto.Debit),
                        new InterestAndFine::AccountingAccount(s.FinancialAccount.Fine.GrantedDebitAccounting.Credit, s.FinancialAccount.Fine.GrantedDebitAccounting.Debit))))
                .ToList());

            return mapper.Map<List<InterestAndFine::InterestAndFineFinancialAccount>>(list);
        }

        public List<CreditGranted::CreditGrantedFinancialAccount> GetAllCreditGrantedFinancialAccount()
        {
            var apiUrl = Environment.GetEnvironmentVariable("FINANCIAL_ACCOUNTS_API");
            var request = new RestRequest("/api/CreditGrantedFinancialAccount/GetAll", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());

            var response = service.ExecuteAndGetContent<List<CreditGrantedFinancialAccountDto>>(apiUrl, request);

            var list = new List<CreditGranted::CreditGrantedFinancialAccount>();

            list.AddRange(response
                .Select(s => new CreditGranted::CreditGrantedFinancialAccount(
                    s.Id,
                    Domain.Util.ToEnum<StoreType>(s.StoreAcronym),
                    s.CreditGrantedAJU,
                    s.AccountingAccountDeb,
                    s.AccountingAccountCred))
                .ToList());

            return mapper.Map<List<CreditGranted::CreditGrantedFinancialAccount>>(list);
        }

        public List<DeferralFinancialAccount> GetAllDeferralFinancialAccount()
        {
            var apiUrl = Environment.GetEnvironmentVariable("FINANCIAL_ACCOUNTS_API");
            var request = new RestRequest("/api/DeferralFinancialAccount/GetAllAccounts", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());

            var response = service.Execute<List<DeferralFinancialAccount>>(apiUrl, request);

            return response;
        }
    }

    public class AccountDetailsByServiceRequest
    {
        [JsonProperty("serviceCodes")]
        public List<string> services { get; set; }
        [JsonProperty("interfaces")]
        public List<string> interfaceTypes { get; set; }

        public AccountDetailsByServiceRequest(List<string> services, List<string> interfaceTypes)
        {
            this.services = services;
            this.interfaceTypes = interfaceTypes;
        }
    }
}

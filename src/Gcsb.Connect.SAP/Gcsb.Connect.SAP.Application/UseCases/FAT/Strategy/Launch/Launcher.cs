using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarACM;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.FATFaturado;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Launch
{
    public class Launcher : ILauncher
    {
        private readonly IMapperService mapperService;

        public int NumberLine { get; private set; }
        public DateTime LaunchDate { get; private set; }
        public string FinancialAccount { get; private set; }
        public decimal LaunchValue { get; private set; }
        public string InternalOrder { get; private set; }
        public DateTime BillingCycle { get; private set; }
        public string Uf { get; private set; }
        public string PaymentMethod { get; private set; }
        public string AccountingEntry { get; private set; }
        public string AccountingAccount { get; private set; }
        public StoreType StoreType { get; private set; }
        public bool IsDiscount { get; private set; }
        public bool HaveIntercompany { get; private set; }
        public bool IsDeferral { get; private set; }

        public Launcher(IMapperService mapperService)
        {
            this.mapperService = mapperService;
        }

        public Launcher(int numberLine, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder, DateTime billingCycle, string uf, string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount, bool haveIntercompany, bool isDeferral)
        {
            NumberLine = numberLine;
            LaunchDate = launchDate;
            FinancialAccount = financialAccount;
            LaunchValue = launchValue;
            InternalOrder = internalOrder;
            BillingCycle = billingCycle;
            Uf = uf;
            PaymentMethod = paymentMethod;
            AccountingEntry = accountingEntry;
            AccountingAccount = accountingAccount;
            StoreType = storeType;
            IsDiscount = isDiscount;
            HaveIntercompany = haveIntercompany;
            IsDeferral = isDeferral;
        }

        public List<ILaunch> GetLaunchFAT(List<LaunchDeferralOffer> launchers, string store, DateTime cycle, int lines, TypeRegister type)
            => type switch
            {
                TypeRegister.FAT => GenerateLaunch<LaunchFaturado>(launchers, store, cycle, lines),
                TypeRegister.FATAFATURARECM => GenerateLaunch<LaunchECM>(launchers, store, cycle, lines),
                TypeRegister.FATAFATURARACM => GenerateLaunch<LaunchACM>(launchers, store, cycle, lines, true),
                _ => throw new NotSupportedException()
            };

        private List<ILaunch> GenerateLaunch<T>(List<LaunchDeferralOffer> launchDeferralOffer, string store, DateTime cycle, int lines, bool isACM = false) where T : ILaunch
        {
            var resultLaunchers = launchDeferralOffer
                     .SelectMany(s => s.AccountingEntries, (launch, account) => new { launch, account })
                     .GroupBy(g => new { g.account.FinancialAccount, g.account.AccountingEntryType, g.account.AccountingAccount, g.launch.Uf, g.launch.PaymentMethod, g.launch.ServiceType.Length, g.launch.LaunchDeferralType })
                     .Select(s => new Launcher(
                         numberLine : ++lines,
                         launchDate : cycle,
                         financialAccount : s.Key.FinancialAccount,
                         launchValue : Convert.ToDecimal(s.Sum(p => ApplyACMCalc(p.launch.LaunchValue, isACM))),
                         internalOrder : Util.GetUF(s.Key.Uf, store.ToStoreType()).InternalOrder,
                         billingCycle : cycle,
                         uf: Util.GetUFByState(s.Key.Uf, store.ToStoreType()),
                         paymentMethod : s.Key.PaymentMethod.RemoveAccents(),
                         accountingEntry : s.Key.AccountingEntryType,
                         accountingAccount : s.Key.AccountingAccount,
                         store.ToStoreType(),
                         isDiscount: false,
                         haveIntercompany : IsIntercompany(s.FirstOrDefault()?.account),
                         isDeferral : true
                     )).ToList();
        

            return mapperService.Map<List<T>>(resultLaunchers).Cast<ILaunch>().ToList();
        }

        private bool IsIntercompany(AccountingEntry account)
            => account.Store != account.Provider;
        
        private double ApplyACMCalc(double value, bool isACM)
            => isACM ? Math.Round((value / 30) * 4, 2) : value;
    }
}

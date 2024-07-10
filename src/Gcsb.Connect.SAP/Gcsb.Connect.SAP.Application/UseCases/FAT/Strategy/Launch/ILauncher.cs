using System;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Launch
{
    public interface ILauncher
    {
        int NumberLine { get; }
        DateTime LaunchDate { get; }
        string FinancialAccount { get; }
        decimal LaunchValue { get;}
        string InternalOrder { get;}
        DateTime BillingCycle { get;}
        string Uf { get;}
        string PaymentMethod { get;}
        string AccountingEntry { get;}
        string AccountingAccount { get;}
        StoreType StoreType { get;}
        bool IsDiscount { get;}
        bool HaveIntercompany { get;}
        bool IsDeferral { get;}

        List<ILaunch> GetLaunchFAT(List<LaunchDeferralOffer> launchers, string store, DateTime cycle, int lines, TypeRegister type);
    }
}

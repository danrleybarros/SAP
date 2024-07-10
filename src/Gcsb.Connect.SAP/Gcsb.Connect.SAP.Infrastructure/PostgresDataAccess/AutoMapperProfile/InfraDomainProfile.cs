using AutoMapper;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Launch;
using Gcsb.Connect.SAP.Domain.GF.Nfe;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.BillFeedSplit.Customer, Domain.JSDN.BillFeedSplit.Customer>().ReverseMap();
            CreateMap<Entities.BillFeedSplit.Invoice, Domain.JSDN.BillFeedSplit.Invoice>().ReverseMap();
            CreateMap<Entities.BillFeedSplit.ServiceInvoice, Domain.JSDN.BillFeedSplit.ServiceInvoice>().ReverseMap();
            CreateMap<Entities.BillFeedDoc, Domain.JSDN.BillFeedDoc>().ReverseMap();
            CreateMap<Entities.File, File>().ReverseMap();
            CreateMap<Entities.FinancialAccount, Domain.Config.FinancialAccount>().ReverseMap();
            CreateMap<Entities.Log, Messaging.Messages.Log.Log>().ReverseMap();
            CreateMap<Entities.LogDetail, Messaging.Messages.Log.LogDetail>().ReverseMap();
            CreateMap<Entities.PaymentFeedDoc, Domain.JSDN.PaymentFeedDoc>().ReverseMap();
            CreateMap<Entities.PaymentCreditCard, Domain.JSDN.PaymentCreditCard>().ReverseMap();
            CreateMap<Entities.PaymentBoleto, Domain.JSDN.PaymentBoleto>().ReverseMap();
            CreateMap<Entities.FinancialAccountDate, Domain.Config.FinancialAccountDate.FinancialAccount>().ReverseMap();
            CreateMap<Entities.ReturnNF, ReturnNF>().ReverseMap();            
            CreateMap<Entities.FinancialAccountDate, Domain.Config.FinancialAccountDate.FinancialAccount>();
            CreateMap<Entities.ManagementFinancialAccount.ManagementFinancialAccount, Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.ARR, Domain.Config.ManagementFinancialAccount.ARR>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.Critic, Domain.Config.ManagementFinancialAccount.Critic>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.Transfer, Domain.Config.ManagementFinancialAccount.Transferred>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.Unassigned, Domain.Config.ManagementFinancialAccount.Unassigned>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.Boleto, Domain.Config.ManagementFinancialAccount.Boleto>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.CreditCard, Domain.Config.ManagementFinancialAccount.CreditCard>().ReverseMap();
            CreateMap<Entities.ManagementFinancialAccount.AccountingAccount, Domain.Config.ManagementFinancialAccount.AccountingAccount>().ReverseMap();
            CreateMap<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount, Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>().ReverseMap();
            CreateMap<Entities.InterestAndFineFinancialAccount.Account, Domain.Config.InterestAndFineFinancialAccount.Account>().ReverseMap();
            CreateMap<Entities.InterestAndFineFinancialAccount.AccountingAccount, Domain.Config.InterestAndFineFinancialAccount.AccountingAccount>().ReverseMap();
            CreateMap<Entities.Pay.Critical, Domain.PAY.Critical>().ReverseMap();
            CreateMap<ApiClients.Entities.CriticalPay, Domain.PAY.Critical>().ReverseMap();
            CreateMap<ApiClients.Entities.InvoicePaymentDto, Domain.PAY.InvoicePayment>().ReverseMap();            
            CreateMap<Entities.CreditGrantedFinancialAccount, Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount>().ReverseMap();
            CreateMap<Entities.Upload, Domain.Upload.Upload>().ReverseMap();            
            CreateMap<Entities.InterfaceProgress, Domain.Upload.InterfaceProgress>().ReverseMap();  
            CreateMap<Entities.CounterchargeDispute, Domain.JSDN.CounterChargeDispute.CounterchargeDispute>().ReverseMap();
            CreateMap<Entities.CreditGrantedFinancialAccount, Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount>().ReverseMap();
            CreateMap<Domain.Upload.Upload, Entities.Upload>().ReverseMap();            
            CreateMap<Domain.Upload.InterfaceProgress, Entities.InterfaceProgress>().ReverseMap();
            CreateMap<Domain.Deferral.StatusActivationService.StatusActivationService, Entities.StatusActivationService>().ReverseMap();
            CreateMap<Domain.Deferral.DeferralOffer, Entities.Deferral.DeferralOffer>().ReverseMap();
            CreateMap<Domain.FAT.FATFaturado.LaunchFaturado, Launcher>().ReverseMap();
            CreateMap<Domain.FAT.FATaFaturarACM.LaunchACM, Launcher>().ReverseMap();
            CreateMap<Domain.FAT.FATaFaturarECM.LaunchECM, Launcher>().ReverseMap();
            CreateMap<ConfigDeferralOffer, Pkg.Datamart.Domain.Deferral.DeferralOffer>().ReverseMap();
            CreateMap<Order, Pkg.Datamart.Domain.Deferral.Order>().ReverseMap();
            CreateMap<Domain.Deferral.DeferralHistory, Entities.Deferral.DeferralHistory>().ReverseMap();          
            CreateMap<Entities.PaymentReport, Domain.JSDN.PaymentReport>().ReverseMap();
        }
    }
}

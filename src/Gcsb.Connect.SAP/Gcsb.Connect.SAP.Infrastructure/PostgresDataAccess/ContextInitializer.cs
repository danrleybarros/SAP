using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess
{
    public static class ContextInitializer
    {
        public static void Seed(Context context)
        {
            string debug = Environment.GetEnvironmentVariable("DEBUG");

            if (!string.IsNullOrEmpty(debug))
            {
                FillFinancialAccount(context);
                FillFinancialAccountDate(context);
            }            
        }

        private static List<Tuple<string, string>> GetServices()
        {
            var services = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("azureactivedirectorypremiumP1", "Azure Active Directory Premium P1"),
                new Tuple<string, string>("AzureInformationProtectionPremiumP2", "Azure Information Protection Premium P2"),
                new Tuple<string, string>("AzureInformationProtectionPlan1", "Azure Information Protection Plan 1"),
                new Tuple<string, string>("AzureAdvancedThreatProtectionforUsers", "Azure Advanced Threat Protection for Users"),
                new Tuple<string, string>("Dynamics365AIforSales", "Dynamics 365 AI for Sales"),
                new Tuple<string, string>("Dynamics365forCustomerServiceEnterprise", "Dynamics 365 for Customer Service Enterprise"),
                new Tuple<string, string>("AzureActiveDirectoryPremiumP2", "Azure Active Directory Premium P2"),
                new Tuple<string, string>("dynamics365forfieldservice", "Dynamics 365 for Field Service"),
                new Tuple<string, string>("dynamics365formarketing", "Dynamics 365 for Marketing"),
                new Tuple<string, string>("dynamics365forretail", "Dynamics 365 for Retail"),
                new Tuple<string, string>("dynamics365forsalesenterprise", "Dynamics 365 for Sales Enterprise"),
                new Tuple<string, string>("dynamics365forsalesenterprisedevice", "Dynamics 365 for Sales Enterprise Device"),
                new Tuple<string, string>("dynamics365forsalesprofessional", "Dynamics 365 for Sales Professional"),
                new Tuple<string, string>("dynamics365layout", "Dynamics 365 Layout"),
                new Tuple<string, string>("Dynamics365Plan", "Dynamics 365 Plan"),
                new Tuple<string, string>("Dynamics365RemoteAssist", "Dynamics 365 Remote Assist"),
                new Tuple<string, string>("Dynamics365TeamMembers", "Dynamics 365 Team Members"),
                new Tuple<string, string>("Dynamics365UnifiedOperationsActivity", "Dynamics 365 Unified Operations Activity"),
                new Tuple<string, string>("Dynamics365UnifiedOperationsDevice", "Dynamics 365 Unified Operations Device"),
                new Tuple<string, string>("Dynamics365UnifiedOperationsPlan", "Dynamics 365 Unified Operations Plan"),
                new Tuple<string, string>("EnterpriseMobilitySecurityE3", "Enterprise Mobility  Security E3"),
                new Tuple<string, string>("ExchangeOnlineKiosk", "Microsoft Exchange Online Kiosk"),
                new Tuple<string, string>("ExchangeOnlinePlan1", "Exchange Online Plan 1"),
                new Tuple<string, string>("ExchangeOnlinePlan2", "Exchange Online Plan 2"),
                new Tuple<string, string>("ExchangeOnlineProtection", "Exchange Online Protection"),
                new Tuple<string, string>("MSintune", "Microsoft Intune"),
                new Tuple<string, string>("MeetingRoom", "Meeting Room"),
                new Tuple<string, string>("Office65Business", "Office 365 Business"),
                new Tuple<string, string>("Microsoft365E3", "Microsoft 365 E3"),
                new Tuple<string, string>("MicrosoftIntuneDevice", "Microsoft Intune Device"),
                new Tuple<string, string>("MicrosoftPowerAppsPlan1", "Microsoft PowerApps Plan 1"),
                new Tuple<string, string>("office365advancedcompliance", "Office 365 Advanced Compliance"),
                new Tuple<string, string>("Office365AdvancedThreatProtectionP2", "Office 365 Advanced Threat Protection Plan 2"),
                new Tuple<string, string>("office365be", "Office 365 Business Essentials"),
                new Tuple<string, string>("Office365BusinessPremium", "Microsoft Office 365 Business Premium"),
                new Tuple<string, string>("Office365EnterpriseE1", "Office 365 Enterprise E1"),
                new Tuple<string, string>("Office365F1", "Office 365 F1"),
                new Tuple<string, string>("Office365ProPlus", "Office 365 ProPlus"),
                new Tuple<string, string>("OneDriveforBusinessPlan1", "OneDrive for Business Plan 1"),
                new Tuple<string, string>("PowerBIPremiumP3", "Power BI Premium P3"),
                new Tuple<string, string>("PowerBIPremiumP1", "Power BI Premium P1"),
                new Tuple<string, string>("PowerBIPro", "Power BI Pro"),
                new Tuple<string, string>("ProjectOnlineEssentials", "Project Online Essentials"),
                new Tuple<string, string>("projectonlinepremium", "Project Online Premium"),
                new Tuple<string, string>("exchangeonlinearchivingeexchangeonline", "Exchange Online Archiving for Exchange Online"),
                new Tuple<string, string>("projectonlineprofessional", "Project Online Professional"),
                new Tuple<string, string>("sharepointonlineplan1", "SharePoint Online Plan 1"),
                new Tuple<string, string>("sharepointonlineplan2", "SharePoint Online Plan 2"),
                new Tuple<string, string>("visioonlineplan1", "Visio Online Plan 1"),
                new Tuple<string, string>("windows10enterprisee3", "Windows 10 Enterprise E3"),
                new Tuple<string, string>("windows10enterprisee3vda", "Windows 10 Enterprise E3 VDA"),
                new Tuple<string, string>("windows10enterprisee5", "Windows 10 Enterprise E5"),
                new Tuple<string, string>("dynamics365forprojectserviceautomation", "Dynamics 365 for Project Service Automation"),
                new Tuple<string, string>("Dynamics365BusinessCentralExternalAccountant", "Dynamics 365 Business Central External Accountant"),
                new Tuple<string, string>("dynamics365forcustomerserviceprofessional", "Dynamics 365 for Customer Service Professional"),
                new Tuple<string, string>("visioonlineplan2", "Visio Online Plan 2"),
                new Tuple<string, string>("skypeforbusinessonlineplan2", "Skype for Business Online Plan 2"),
                new Tuple<string, string>("EnterpriseMobilitySecurityE5", "Enterprise Mobility  Security E5"),
                new Tuple<string, string>("PowerBIPremiumP5", "Power BI Premium P5"),
                new Tuple<string, string>("ExchangeOnlineArchivingforExchangeServer", "Exchange Online Archiving for Exchange Server"),
                new Tuple<string, string>("PowerBIPremiumP4", "Power BI Premium P4"),
                new Tuple<string, string>("PowerBIPremiumP2", "Power BI Premium P2"),
                new Tuple<string, string>("Microsoft365Business", "Microsoft 365 Business"),
                new Tuple<string, string>("OneDriveforBusinessPlan2", "OneDrive for Business Plan 2"),
                new Tuple<string, string>("Microsoft365E5", "Microsoft 365 E5"),
                new Tuple<string, string>("Office365EnterpriseE3", "Office 365 Enterprise E3"),
                new Tuple<string, string>("office356bp", "Old Office 365 Business Premium"),
                new Tuple<string, string>("MicrosoftPowerAppsPlan2", "Microsoft PowerApps Plan 2"),
                new Tuple<string, string>("Microsoft365F1", "Microsoft 365 F1"),
                new Tuple<string, string>("dynamics365forfieldservicedevice", "Dynamics 365 for Field Service Device"),
                new Tuple<string, string>("azurecsplinuxstack", "Vivo Cloud Azure"),
                new Tuple<string, string>("msflowPlan1", "Microsoft Flow Plan 1"),
                new Tuple<string, string>("Dynamics365BusinessCentralEssential", "Dynamics 365 Business Central Essential"),
                new Tuple<string, string>("Dynamics365BusinessCentralPremium", "Dynamics 365 Business Central Premium"),
                new Tuple<string, string>("Dynamics365BusinessCentralTeamMember", "Dynamics 365 Business Central Team Member"),
                new Tuple<string, string>("Dynamics365forCustomerServiceEnterpriseDevice", "Dynamics 365 for Customer Service Enterprise Device"),
                new Tuple<string, string>("Dynamics365forTalent", "Dynamics 365 for Talent"),
                new Tuple<string, string>("microsoftkaizalapro", "Microsoft Kaizala Pro"),
                new Tuple<string, string>("Office365EnterpriseE5", "Office 365 Enterprise E5"),
                new Tuple<string, string>("AzureActiveDirectoryBasic", "Azure Active Directory Basic"),
                new Tuple<string, string>("microsoftazureubuntustack", "MicrosoftAzure Ubuntu Stack"),
                new Tuple<string, string>("microsoftazurewindowsstack", "MicrosoftAzure Windows Stack"),
                new Tuple<string, string>("AdvancedeDiscoveryStorage", "Advanced eDiscovery Storage"),
                new Tuple<string, string>("AudioConferencing", "Audio Conferencing"),
                new Tuple<string, string>("Dynamics365AdditionalDatabaseStorage", "Dynamics 365 Additional Database Storage"),
                new Tuple<string, string>("Dynamics365AdditionalNonProductionInstance", "Dynamics 365 Additional Non-Production Instance"),
                new Tuple<string, string>("MicrosoftCloudAppSecurity", "Microsoft Cloud App Security"),
                new Tuple<string, string>("msflowPlan2", "Microsoft Flow Plan 2"),
                new Tuple<string, string>("Office365BusinessEssentials", "Office 365 Business Essentials ")
            };

            return services;
        }
        private static List<Tuple<string, string>> GetIaasServices()
        {
            var services = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("newazurecspsubscriptionservice" ,"newazurecspsubscriptionservice" ),
                new Tuple<string, string>("jamcrackeropenstackvivosubscriptionservice" ,"jamcrackeropenstackvivosubscriptionservice" )
            };

            return services;
        }

        private static void FillFinancialAccount(Context context)
        {
            if (!context.FinancialAccount.Any())
            {
                var services = GetServices();
                var servicesIaas = GetIaasServices();

                services.ForEach(f =>
                {
                    context.FinancialAccount.Add(
                        new FinancialAccount
                        {
                            Id = Guid.NewGuid(),
                            ServiceCode = f.Item1,
                            ServiceCodeName = f.Item2,
                            FaturamentoAJU = "FATOFFICE365GW",
                            FaturamentoFAT = "FATOFFICE365GW",
                            DescontoFAT = "DESCOFFICE365GW",
                            ContaContabilAjusteCompetenciaCred = "AJUCOMPC",
                            ContaContabilAjusteCompetenciaDeb = "AJUDCOMD",
                            ContaContabilEstimativaCicloCred = "ESTMIC",
                            ContaContabilEstimativaCicloDeb = "ESTIMD"
                        });
                });

                servicesIaas.ForEach(f =>
                {
                    context.FinancialAccount.Add(new FinancialAccount
                    {
                        Id = Guid.NewGuid(),
                        ServiceCode = f.Item1,
                        ServiceCodeName = f.Item2,
                        FaturamentoAJU = "FATCLOUDGW",
                        FaturamentoFAT = "FATCLOUDGW",
                        DescontoFAT = "DESCCLOUDGW",
                        ContaContabilAjusteCompetenciaCred = "AJUCOMPC",
                        ContaContabilAjusteCompetenciaDeb = "AJUDCOMD",
                        ContaContabilEstimativaCicloCred = "ESTMIC",
                        ContaContabilEstimativaCicloDeb = "ESTIMD"
                    });
                });

                context.SaveChanges();
            }
        }

        private static void FillFinancialAccountDate(Context context)
        {
            if (!context.FinancialAccountDate.Any())
            {
                var financialAccounts = context.FinancialAccount.ToList();

                financialAccounts.ForEach(f =>
                {
                    context.FinancialAccountDate.Add(
                        new FinancialAccountDate
                        {
                            Id = Guid.NewGuid(),
                            IdFinancialAccount = f.Id,
                            ServiceCode = f.ServiceCode,
                            ServiceName = f.ServiceCodeName,
                            FaturamentoAJU = f.FaturamentoFAT,
                            FaturamentoFAT = f.FaturamentoAJU,
                            DescontoFAT = f.DescontoFAT,
                            DateIncluded = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                            LastUpdateDate = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            ContaContabilAjusteCompetenciaCred = "AJUCOMPC",
                            ContaContabilAjusteCompetenciaDeb = "AJUDCOMD",
                            ContaContabilEstimativaCicloCred = "ESTMIC",
                            ContaContabilEstimativaCicloDeb = "ESTIMD"
                        });
                });

                context.SaveChanges();
            }
        }
    }
}

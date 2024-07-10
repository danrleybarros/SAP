using Gcsb.Connect.SAP.Domain.GF;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class IndividualReportNFBuilder
    {
        public IndividualReportNFBuilder()
        {
            Defaults();
        }

        public string CCM;
        public DateTime InitialDate;
        public DateTime EndDate;
        public string Reference;
        public DateTime InvoiceCreationDate;
        public string LocationServiceProvision;
        public double TotalNFValue;
        public string CityHallServiceCode;
        public int ISSAliquot;
        public string CPF;
        public string CNPJ;
        public DateTime DateDueInvoice;
        public string ExpiryCode;
        public string ServiceCode;
        public double Quantity;
        public string Unity;
        public string Description;
        public double UnityValue;
        public string CompanyName;
        public string StateRegistration;
        public string MailingStreet;
        public string MailingNumber;
        public string Address;
        public string County;
        public string UF;
        public string ZipCode;
        public string CustomerEmail;
        public string BillingAddress;
        public string BillingNumberAddress;
        public string CNPJ_CPF_Tomador;
        public DateTime CycleFatDate;
        public string StoreAcronym;

        public void Defaults()
        {
            CCM = "1";
            InitialDate = DateTime.UtcNow.AddMonths(-1);
            EndDate = DateTime.UtcNow;
            Reference = "VVL-1-00001066";
            InvoiceCreationDate = DateTime.UtcNow;
            LocationServiceProvision = "1";
            TotalNFValue = 1000;
            CityHallServiceCode = "SP";
            ISSAliquot = 2;
            CNPJ = "05.234.545/0001-47";
            CPF = "156.093.126-47";
            DateDueInvoice = DateTime.UtcNow;
            ExpiryCode = "001";
            ServiceCode = "sharepointonlineplan1";
            Quantity = 1;
            Unity = "UM";
            Description = "SharePoint Online Plan 1";
            UnityValue = 22.99;
            CompanyName = "Koritar Compra II";
            StateRegistration = "623111541113";
            MailingStreet = "Av Tamboré";
            MailingNumber = "320";
            County = "São Paulo";
            UF = "SP";
            ZipCode = "06460-000";
            CustomerEmail = "srvlsn.e@gmail.com";
            BillingAddress = "Av Tamboré";
            BillingNumberAddress = "320";
            CycleFatDate = DateTime.UtcNow.AddMonths(-1);
            StoreAcronym = "telerese";
        }

        public IndividualReportNFBuilder WithCCM(string ccm)
        {
            CCM = ccm;
            return this;
        }

        public IndividualReportNFBuilder WithInitialDate(DateTime initialdate)
        {
            InitialDate = initialdate;
            return this;
        }

        public IndividualReportNFBuilder WithEndDate(DateTime enddate)
        {
            EndDate = enddate;
            return this;
        }

        public IndividualReportNFBuilder WithReference(string reference)
        {
            Reference = reference;
            return this;
        }

        public IndividualReportNFBuilder WithInvoiceCreationDate(DateTime invoicecreationdate)
        {
            InvoiceCreationDate = invoicecreationdate;
            return this;
        }

        public IndividualReportNFBuilder WithLocationServiceProvision(string locationserviceprovision)
        {
            LocationServiceProvision = locationserviceprovision;
            return this;
        }

        public IndividualReportNFBuilder WithTotalNFValue(double totalnfvalue)
        {
            TotalNFValue = totalnfvalue;
            return this;
        }

        public IndividualReportNFBuilder WithCityHallServiceCode(string cityhallservicecode)
        {
            CityHallServiceCode = cityhallservicecode;
            return this;
        }

        public IndividualReportNFBuilder WithISSAliquot(int issaliquot)
        {
            ISSAliquot = issaliquot;
            return this;
        }

        public IndividualReportNFBuilder WithCPF(string cpf)
        {
            CPF = cpf;
            return this;
        }

        public IndividualReportNFBuilder WithCNPJ(string cnpj)
        {
            CNPJ = cnpj;
            return this;
        }

        public IndividualReportNFBuilder WithDateDueInvoice(DateTime datedueinvoice)
        {
            DateDueInvoice = datedueinvoice;
            return this;
        }

        public IndividualReportNFBuilder WithExpiryCode(string expirycode)
        {
            ExpiryCode = expirycode;
            return this;
        }

        public IndividualReportNFBuilder WithUnityValue(double unityvalue)
        {
            UnityValue = unityvalue;
            return this;
        }

        public IndividualReportNFBuilder WithCompanyName(string companyname)
        {
            CompanyName = companyname;
            return this;
        }

        public IndividualReportNFBuilder WithStateRegistration(string stateregistration)
        {
            StateRegistration = stateregistration;
            return this;
        }

        public IndividualReportNFBuilder WithMailingStreet(string mailingstreet)
        {
            MailingStreet = mailingstreet;
            return this;
        }

        public IndividualReportNFBuilder WithMailingNumber(string mailingnumber)
        {
            MailingNumber = mailingnumber;
            return this;
        }

        public IndividualReportNFBuilder WithCounty(string county)
        {
            County = county;
            return this;
        }

        public IndividualReportNFBuilder WithUF(string uf)
        {
            UF = uf;
            return this;
        }

        public IndividualReportNFBuilder WithZipCode(string zipcode)
        {
            ZipCode = zipcode;
            return this;
        }

        public IndividualReportNFBuilder WithCustomerEmail(string customeremail)
        {
            CustomerEmail = customeremail;
            return this;
        }

        public IndividualReportNFBuilder WithBillingAddress(string billingaddress)
        {
            BillingAddress = billingaddress;
            return this;
        }

        public IndividualReportNFBuilder WithBillingNumberAddress(string billingnumberaddress)
        {
            BillingNumberAddress = billingnumberaddress;
            return this;
        }

        public IndividualReportNFBuilder WithCPF_CNPJ_Tomador(string cpf_cnpj_tomador)
        {
            CNPJ_CPF_Tomador = cpf_cnpj_tomador;
            return this;
        }

        public IndividualReportNFBuilder WithCycleFatDate(DateTime cycleFatDate)
        {
            CycleFatDate = cycleFatDate;
            return this;
        }

        public IndividualReportNFBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public IndividualReportNF Build()
            => new IndividualReportNF(CCM,
                InitialDate,
                EndDate,
                Reference,
                InvoiceCreationDate,
                TotalNFValue,
                CityHallServiceCode,
                ISSAliquot,
                CPF,
                CNPJ,
                DateDueInvoice,
                UnityValue,
                CompanyName,
                StateRegistration,
                MailingStreet,
                MailingNumber,
                County,
                UF,
                ZipCode,
                CustomerEmail,
                BillingAddress,
                BillingNumberAddress,
                CycleFatDate,
                StoreAcronym);

    }
}
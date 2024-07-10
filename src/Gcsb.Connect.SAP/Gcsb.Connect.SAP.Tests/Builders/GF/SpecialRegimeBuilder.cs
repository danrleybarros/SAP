using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
	public class SpecialRegimeBuilder
	{
		public string InvoiceNumber;
		public string AffiliateCode;
		public string ServiceCode;
		public string ServiceName;
		public string NF;
		public string Serie;
		public DateTime InvoiceCreationDate;
		public string CompanyName;
		public decimal TotalInvoicePrice;
		public decimal TotalRetailPriceDiscount;
		public decimal CreditValue;
		public decimal GrossRetailPrice;
		public decimal PercentISS;
		public decimal TotalTax;
		public string Cfop;
		public string RG;
		public string Cnpj;
		public string InvoiceNumberRefDocOrigem;
		public DateTime? ReversalDate;
		public string CityBilling;
		public string ZipCodeBilling;
		public string StreetBilling;
		public string Zone;
		public string Cpf;
		public string CnpjMarketPlace;
		public string CompanyNameMarketPlace;
		public string MunicipalTaxpayerRegistration;
		public string SpecialProcedureNumber;
		public string ServiceCodeCity;
		public string CustomerCode;
		public DateTime DueDate;
		public DateTime CycleFatDate;
		public string StoreAcronym;

		public static SpecialRegimeBuilder New()
		{
			return new SpecialRegimeBuilder
			{
				InvoiceNumber = "InvoiceNumber",
				ServiceCode = "SerCode",
				ServiceName = "SeName",
				InvoiceCreationDate = DateTime.Now,
				CompanyName = "CyName",
				TotalInvoicePrice = 1000.34M,
				TotalRetailPriceDiscount = 2000.11M,
				CreditValue = -50.00m,
				GrossRetailPrice = 3000M,
				PercentISS = 50,
				TotalTax = 100,
				Cnpj = "31240319000118",
				InvoiceNumberRefDocOrigem = "IefDocOrm",
				ReversalDate = null,
				CityBilling = "Citng",
				ZipCodeBilling = "09121-130",
				StreetBilling = "teste",
				Cpf = "53299600028",
				CnpjMarketPlace = "31240319000118",
				CompanyNameMarketPlace = "CompMarklace",
				CustomerCode = "666",
				DueDate = DateTime.Now,
				CycleFatDate = DateTime.Now,
				StoreAcronym = "telerese",
				MunicipalTaxpayerRegistration = "77434",
				SpecialProcedureNumber = "002/2018",
				ServiceCodeCity = "1.03"
			};
		}

		public SpecialRegimeBuilder WithInvoiceNumber(string invoicenumber)
		{
			InvoiceNumber = invoicenumber;
			return this;
		}

		public SpecialRegimeBuilder WithAffiliateCode(string affiliatecode)
		{
			AffiliateCode = affiliatecode;
			return this;
		}

		public SpecialRegimeBuilder WithServiceCode(string servicecode)
		{
			ServiceCode = servicecode;
			return this;
		}

		public SpecialRegimeBuilder WithServiceName(string servicename)
		{
			ServiceName = servicename;
			return this;
		}

		public SpecialRegimeBuilder WithNF(string nf)
		{
			NF = nf;
			return this;
		}

		public SpecialRegimeBuilder WithSerie(string serie)
		{
			Serie = serie;
			return this;
		}

		public SpecialRegimeBuilder WithInvoiceCreationDate(DateTime invoicecreationdate)
		{
			InvoiceCreationDate = invoicecreationdate;
			return this;
		}

		public SpecialRegimeBuilder WithCompanyName(string companyname)
		{
			CompanyName = companyname;
			return this;
		}

		public SpecialRegimeBuilder WithTotalInvoicePrice(decimal totalinvoiceprice)
		{
			TotalInvoicePrice = totalinvoiceprice;
			return this;
		}

		public SpecialRegimeBuilder WithTotalRetailPriceDiscount(decimal totalretailpricediscount)
		{
			TotalRetailPriceDiscount = totalretailpricediscount;
			return this;
		}

		public SpecialRegimeBuilder WithCreditValue(decimal creditValue)
		{
			CreditValue = creditValue;
			return this;
		}

		public SpecialRegimeBuilder WithGrossRetailPrice(decimal grossretailprice)
		{
			GrossRetailPrice = grossretailprice;
			return this;
		}

		public SpecialRegimeBuilder WithPercentISS(decimal percentiss)
		{
			PercentISS = percentiss;
			return this;
		}

		public SpecialRegimeBuilder WithTotalTax(decimal totaltax)
		{
			TotalTax = totaltax;
			return this;
		}

		public SpecialRegimeBuilder WithCfop(string cfop)
		{
			Cfop = cfop;
			return this;
		}

		public SpecialRegimeBuilder WithRG(string rg)
		{
			RG = rg;
			return this;
		}

		public SpecialRegimeBuilder WithCnpj(string cnpj)
		{
			Cnpj = cnpj;
			return this;
		}

		public SpecialRegimeBuilder WithInvoiceNumberRefDocOrigem(string invoicenumberrefdocorigem)
		{
			InvoiceNumberRefDocOrigem = invoicenumberrefdocorigem;
			return this;
		}

		public SpecialRegimeBuilder WithReversalDate(DateTime? reversaldate)
		{
			ReversalDate = reversaldate;
			return this;
		}

		public SpecialRegimeBuilder WithCityBilling(string citybilling)
		{
			CityBilling = citybilling;
			return this;
		}

		public SpecialRegimeBuilder WithZipCodeBilling(string zipcodebilling)
		{
			ZipCodeBilling = zipcodebilling;
			return this;
		}

		public SpecialRegimeBuilder WithStreetBilling(string streetbilling)
		{
			StreetBilling = streetbilling;
			return this;
		}

		public SpecialRegimeBuilder WithZone(string zone)
		{
			Zone = zone;
			return this;
		}

		public SpecialRegimeBuilder WithCpf(string cpf)
		{
			Cpf = cpf;
			return this;
		}

		public SpecialRegimeBuilder WithCnpjMarketPlace(string cnpjmarketplace)
		{
			CnpjMarketPlace = cnpjmarketplace;
			return this;
		}

		public SpecialRegimeBuilder WithCompanyNameMarketPlace(string companynamemarketplace)
		{
			CompanyNameMarketPlace = companynamemarketplace;
			return this;
		}

		public SpecialRegimeBuilder WithMunicipalTaxpayerRegistration(string municipaltaxpayerregistration)
		{
			MunicipalTaxpayerRegistration = municipaltaxpayerregistration;
			return this;
		}

		public SpecialRegimeBuilder WithSpecialProcedureNumber(string specialprocedurenumber)
		{
			SpecialProcedureNumber = specialprocedurenumber;
			return this;
		}

		public SpecialRegimeBuilder WithServiceCodeCity(string servicecodecity)
		{
			ServiceCodeCity = servicecodecity;
			return this;
		}

		public SpecialRegimeBuilder WithCustomerCode(string customercode)
		{
			CustomerCode = customercode;
			return this;
		}

		public SpecialRegimeBuilder WithDueDate(DateTime duedate)
		{
			DueDate = duedate;
			return this;
		}

		public SpecialRegimeBuilder WithCycleFatDate(DateTime cycleFatDate)
		{
			CycleFatDate = cycleFatDate;
			return this;
		}

		public SpecialRegimeBuilder WithStoreAcronym(string storeAcronym)
		{
			StoreAcronym = storeAcronym;
			return this;
		}

		public Domain.GF.SpecialRegime Build()
			=> new Domain.GF.SpecialRegime(
				InvoiceNumber,
				ServiceCode,
				ServiceName,
				InvoiceCreationDate,
				CompanyName,
				TotalInvoicePrice,
				TotalRetailPriceDiscount,
				CreditValue,
				GrossRetailPrice,
				PercentISS,
				TotalTax,
				Cnpj,
				InvoiceNumberRefDocOrigem,
				CityBilling,
				ZipCodeBilling,
				StreetBilling,
				Cpf,
				CnpjMarketPlace,
				CompanyNameMarketPlace,
				MunicipalTaxpayerRegistration,
				SpecialProcedureNumber,
				ServiceCodeCity,
				CustomerCode,
				DueDate,
				CycleFatDate,
				StoreAcronym);
	}
}

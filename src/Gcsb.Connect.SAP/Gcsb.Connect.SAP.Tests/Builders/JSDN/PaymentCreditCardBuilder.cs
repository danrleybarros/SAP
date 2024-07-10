using AutoMapper;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{	
	public class PaymentCreditCardBuilder
	{
		#region Mapper

		private void ConfigMap(IMapperConfigurationExpression cfg) =>
			cfg.CreateMap<PaymentCreditCardBuilder, PaymentCreditCard>()
				.ConstructUsing(src => new PaymentCreditCard(Guid.NewGuid(),
					src.ResultCode,
					src.Description,
					src.VersionId,
					src.TerminalId,
					src.AcquirerEntity, //Ver
					src.MerchantId,
					src.ServiceId,
					src.UserId,
					src.TypeOperation,
					src.ProcessCode,
					src.OrderId,
					src.CardPan,
					src.CardExpirationDate,
					src.TransactionAmount,
					src.MerchantCurrency,
					src.Currency,
					src.OriginIPAddress,
					"", //DateTimeSIA
					"", //PaymentDateTime
					src.TransactionDate,
					src.SIAOperationNumber,
					src.AuthorizationID,
					src.AlternativeAmount,
					src.AlternativeCurrency,
					src.CustomerEmail,
					src.MerchantSession,
					src.BatchID,
					src.DataPrint,
					src.UrlPuce,
					src.UrlAuthPath,
					src.AcquirerEntity,
					src.PlanType,
					src.InstallmentsNumber,
					src.GracePeriod,
					src.InterestAmount,
					src.ExtendedSIAOperationNumber,
					src.AcquirerTransactionID,
					src.BankIdentificationNumber,
					src.CardIssuer,
					src.CardIssuerCountry,
					src.CardBrand,
					src.CardCategory,
					src.CardType,
					src.InvoiceNumberJsdn,
					DateTime.Now, 
					PaymentDate, 
					CreditCard, 
					CreditCardNSU, 
					AuthorizationCode, 
					CardLabel, 
					Acquirer, 
					PaymentValue
					));

		#endregion

		private readonly IMapper mapper;

		public PaymentCreditCardBuilder()
		{
			Defaults();

			mapper = new MapperConfiguration(cfg => ConfigMap(cfg)).CreateMapper();
		}

		#region Properties
			
		public int ResultCode; 	
		public string Description; 	
		public string VersionId; 	
		public string TerminalId; 	
		public string MerchantId; 	
		public int? ServiceId; 	
		public string UserId; 	
		public string TypeOperation; 	
		public string ProcessCode; 	
		public string OrderId; 	
		public string CardPan; 	
		public string CardExpirationDate; 	
		public int? MerchantCurrency; 	
		public string Currency; 	
		public string OriginIPAddress; 	
		public int? SIAOperationNumber; 	
		public string AuthorizationID; 	
		public decimal? AlternativeAmount; 	
		public decimal? TransactionAmount; 	
		public int? AlternativeCurrency; 	
		public string CustomerEmail; 	
		public string MerchantSession; 	
		public int? BatchID; 	
		public string DataPrint; 	
		public string UrlPuce; 	
		public string UrlAuthPath; 	
		public string AcquirerEntity; 	
		public string PlanType; 	
		public int? InstallmentsNumber; 	
		public int? GracePeriod; 	
		public decimal? InterestAmount; 	
		public long? ExtendedSIAOperationNumber; 	
		public string AcquirerTransactionID; 	
		public int? BankIdentificationNumber; 	
		public string CardIssuer; 	
		public int? CardIssuerCountry; 	
		public int? CardBrand; 	
		public int? CardCategory; 	
		public string CardType; 		
		public string InvoiceNumberJsdn;
		public string PaymentDate;
		public string CreditCard;
		public string CreditCardNSU;
		public string AuthorizationCode;
		public string CardLabel;
		public string Acquirer;
		public decimal? PaymentValue;
		public DateTime TransactionDate;
		#endregion

		#region With Methods
		public PaymentCreditCardBuilder WithTransactionDate(DateTime dateTime)
		{
			TransactionDate = dateTime;
			return this;
		}

		public PaymentCreditCardBuilder WithResultCode(int resultcode)
		{
			ResultCode = resultcode;
			return this;
		}
		
		public PaymentCreditCardBuilder WithDescription(string description)
		{
			Description = description;
			return this;
		}

		public PaymentCreditCardBuilder WithInvoiceNumberJsdn(string invoiceNumber)
		{
			InvoiceNumberJsdn = invoiceNumber;
			return this;
		}

		public PaymentCreditCardBuilder WithVersionId(string versionid)
		{
			VersionId = versionid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithTerminalId(string terminalid)
		{
			TerminalId = terminalid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithMerchantId(string merchantid)
		{
			MerchantId = merchantid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithServiceId(int? serviceid)
		{
			ServiceId = serviceid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithUserId(string userid)
		{
			UserId = userid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithTypeOperation(string typeoperation)
		{
			TypeOperation = typeoperation;
			return this;
		}
		
		public PaymentCreditCardBuilder WithProcessCode(string processcode)
		{
			ProcessCode = processcode;
			return this;
		}
		
		public PaymentCreditCardBuilder WithOrderId(string orderid)
		{
			OrderId = orderid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardPan(string cardpan)
		{
			CardPan = cardpan;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardExpirationDate(string cardexpirationdate)
		{
			CardExpirationDate = cardexpirationdate;
			return this;
		}
		
		public PaymentCreditCardBuilder WithMerchantCurrency(int? merchantcurrency)
		{
			MerchantCurrency = merchantcurrency;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCurrency(string currency)
		{
			Currency = currency;
			return this;
		}
		
		public PaymentCreditCardBuilder WithOriginIPAddress(string originipaddress)
		{
			OriginIPAddress = originipaddress;
			return this;
		}
		
		public PaymentCreditCardBuilder WithSIAOperationNumber(int? siaoperationnumber)
		{
			SIAOperationNumber = siaoperationnumber;
			return this;
		}
		
		public PaymentCreditCardBuilder WithAuthorizationID(string authorizationid)
		{
			AuthorizationID = authorizationid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithAlternativeAmount(decimal? alternativeamount)
		{
			AlternativeAmount = alternativeamount;
			return this;
		}

		public PaymentCreditCardBuilder WithTransactionAmount(decimal? transactionAmount)
		{
			TransactionAmount = transactionAmount;
			return this;
		}

		public PaymentCreditCardBuilder WithAlternativeCurrency(int? alternativecurrency)
		{
			AlternativeCurrency = alternativecurrency;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCustomerEmail(string customeremail)
		{
			CustomerEmail = customeremail;
			return this;
		}
		
		public PaymentCreditCardBuilder WithMerchantSession(string merchantsession)
		{
			MerchantSession = merchantsession;
			return this;
		}
		
		public PaymentCreditCardBuilder WithBatchID(int? batchid)
		{
			BatchID = batchid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithDataPrint(string dataprint)
		{
			DataPrint = dataprint;
			return this;
		}
		
		public PaymentCreditCardBuilder WithUrlPuce(string urlpuce)
		{
			UrlPuce = urlpuce;
			return this;
		}
		
		public PaymentCreditCardBuilder WithUrlAuthPath(string urlauthpath)
		{
			UrlAuthPath = urlauthpath;
			return this;
		}
		
		public PaymentCreditCardBuilder WithAcquirerEntity(string acquirerentity)
		{
			AcquirerEntity = acquirerentity;
			return this;
		}
		
		public PaymentCreditCardBuilder WithPlanType(string plantype)
		{
			PlanType = plantype;
			return this;
		}
		
		public PaymentCreditCardBuilder WithInstallmentsNumber(int? installmentsnumber)
		{
			InstallmentsNumber = installmentsnumber;
			return this;
		}
		
		public PaymentCreditCardBuilder WithGracePeriod(int? graceperiod)
		{
			GracePeriod = graceperiod;
			return this;
		}
		
		public PaymentCreditCardBuilder WithInterestAmount(decimal? interestamount)
		{
			InterestAmount = interestamount;
			return this;
		}
		
		public PaymentCreditCardBuilder WithExtendedSIAOperationNumber(long? extendedsiaoperationnumber)
		{
			ExtendedSIAOperationNumber = extendedsiaoperationnumber;
			return this;
		}
		
		public PaymentCreditCardBuilder WithAcquirerTransactionID(string acquirertransactionid)
		{
			AcquirerTransactionID = acquirertransactionid;
			return this;
		}
		
		public PaymentCreditCardBuilder WithBankIdentificationNumber(int? bankidentificationnumber)
		{
			BankIdentificationNumber = bankidentificationnumber;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardIssuer(string cardissuer)
		{
			CardIssuer = cardissuer;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardIssuerCountry(int? cardissuercountry)
		{
			CardIssuerCountry = cardissuercountry;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardBrand(int? cardbrand)
		{
			CardBrand = cardbrand;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardCategory(int? cardcategory)
		{
			CardCategory = cardcategory;
			return this;
		}
		
		public PaymentCreditCardBuilder WithCardType(string cardtype)
		{
			CardType = cardtype;
			return this;
		}

		public PaymentCreditCardBuilder WithPaymentDate(string paymentDate)
		{
			PaymentDate = paymentDate;
			return this;
		}

		public PaymentCreditCardBuilder WithCreditCard(string creditCard)
		{
			CreditCard = creditCard;
			return this;
		}

		public PaymentCreditCardBuilder WithCreditCardNSU(string creditCardNSU)
		{
			CreditCardNSU = creditCardNSU;
			return this;
		}

		public PaymentCreditCardBuilder WithAuthorizationCode(string authorizationCode)
		{
			AuthorizationCode = authorizationCode;
			return this;
		}

		public PaymentCreditCardBuilder WithCardLabel(string cardLabel)
		{
			CardLabel = cardLabel;
			return this;
		}

		public PaymentCreditCardBuilder WithAcquirer(string acquirer)
		{
			Acquirer = acquirer;
			return this;
		}

		public PaymentCreditCardBuilder WithPaymentValue(decimal? paymentValue)
		{
			PaymentValue = paymentValue;
			return this;
		}
		#endregion

		#region Build
		public PaymentCreditCard Build() => mapper.Map<PaymentCreditCard>(this);
		#endregion

		#region Default Methods 
	    public new void Defaults()
        {
									ResultCode = 1;
									/*** maxlength : 50 ****/
						Description = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
									/*** maxlength : 4 ****/
						VersionId = "AAAA";
									/*** maxlength : 11 ****/
						TerminalId = "AAAAAAAAAAA";
									/*** maxlength : 15 ****/
						MerchantId = "AAAAAAAAAAAAAAA";
									/*** maxlength : 50 ****/
						UserId = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
									/*** maxlength : 4 ****/
						TypeOperation = "AAAA";
			        }
		#endregion
	}
}

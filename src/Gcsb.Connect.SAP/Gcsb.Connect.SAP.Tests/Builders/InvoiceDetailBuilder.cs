using Gcsb.Connect.SAP.Domain;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class InvoiceDetailBuilder
    {
        public string MaterialCode;
        public int Amount;
        public decimal VendorPrice;
        public decimal? PISTax;
        public decimal? COFINSTax;
        public decimal? ISSTax;
        public decimal ICMSTax;
        public decimal? Chargeback;
        public DateTime? ActivationDate;
        public DateTime? DateOfInactivation;
        public int? Origin;

        public static InvoiceDetailBuilder New()
        {
            return new InvoiceDetailBuilder
            {                
                MaterialCode = "MaterialCodeTest",
                Amount = 1,
                VendorPrice = 2.99m,
                PISTax = 2.99m,
                COFINSTax = 2.99m,
                ISSTax = 2.99m,
                ICMSTax = 2.99m,
                Chargeback = 2.99m,
                ActivationDate = DateTime.Now,
                DateOfInactivation = DateTime.Now,
                Origin = 8
            };
        }

        public InvoiceDetailBuilder WithMaterialCode(string materialCode)
        {
            MaterialCode = materialCode;
            return this;
        }

        public InvoiceDetailBuilder WithAmount(int amount)
        {
            Amount = amount;
            return this;
        }

        public InvoiceDetailBuilder WithVendorPrice(decimal vendorPrice)
        {
            VendorPrice = vendorPrice;
            return this;
        }

        public InvoiceDetailBuilder WithPISTax(decimal? pisTax)
        {
            PISTax = pisTax;
            return this;
        }

        public InvoiceDetailBuilder WithCOFINSTax(decimal? cofinsTax)
        {
            COFINSTax = cofinsTax;
            return this;
        }

        public InvoiceDetailBuilder WithISSTax(decimal? issTax)
        {
            ISSTax = issTax;
            return this;
        }
    
        public InvoiceDetailBuilder WithICMSTax(decimal icmsTax)
        {
            ICMSTax = icmsTax;
            return this;
        }

        public InvoiceDetailBuilder WithChargeback(decimal? chargeback)
        {
            Chargeback = chargeback;
            return this;
        }

        public InvoiceDetailBuilder WithActivationDate(DateTime? activationDate)
        {
            ActivationDate = activationDate;
            return this;
        }

        public InvoiceDetailBuilder WithDateOfInactivation(DateTime? dateOfInactivation)
        {
            DateOfInactivation = dateOfInactivation;
            return this;
        }

        public InvoiceDetailBuilder WithOrigin(int? origin)
        {
            Origin = origin;
            return this;
        }

        public InvoiceDetail Build()
        {
            return new InvoiceDetail(MaterialCode, Amount, VendorPrice, PISTax, COFINSTax, ISSTax, ICMSTax, Chargeback, ActivationDate, DateOfInactivation, Origin);
        }
    }
}

using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class PrepareDataHandler : Handler
    {
        public override void ProcessRequest(ClientChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Consulting data and grouping result - Client GF"));

            request.Clients = GroupByServiceCode(request.Customers, request.Address);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<Domain.GF.Client> GroupByServiceCode(List<Customer> customers, List<Domain.GF.CepOutput> address)
            => customers.Select(s => new Domain.GF.Client(
                 $"GW{s.CustomerCode.PadLeft(14, '0')}",
                Domain.Util.LastDayOfThePreviousMonth(s.Invoice),
                //TODO: Este metodo GetUFByState para pegar UF é temporario, quando houver a consistencia dos dados peja JAM substituir pelo metodo abaixo
                ReturnCorrectValue(address.Where(w => w.Cep.Equals(s.BillingZIPcode)).Select(o => o.Uf).FirstOrDefault(), Util.GetUFByState(s.BillingStateOrProvince, StoreType.TBRA)),
                ReturnCorrectValue(s.CustomerCNPJ, s.CustomerCPF).PadRight(16, '0'),
                VerifyCustumerType(s.CustomerCNPJ),
                s.CustomerStateRegistration,
                s.CompanyName,
                ReturnCorrectValue(address.Where(w => w.Cep.Equals(s.BillingZIPcode)).Select(o => o.NomeLogradouro).FirstOrDefault(), s.BillingStreet),
                Regex.Replace(s.BillingNumber, "[\\D]", "0").PadLeft(12, '0'),
                s.BillingComplement,
                ReturnCorrectValue(address.Where(w => w.Cep.Equals(s.BillingZIPcode)).Select(o => o.Bairro).FirstOrDefault(), s.BillingNeighbourhood),
                ReturnCorrectValue(address.Where(w => w.Cep.Equals(s.BillingZIPcode)).Select(o => o.NomeLocalidade).FirstOrDefault(), s.BillingStateOrProvince),
                s.BillingZIPcode,
                address.Where(w => w.Cep.Equals(s.BillingZIPcode)).Select(o => o.CodigoIbge.ToString()).FirstOrDefault()
            )).ToList();

        private string VerifyCustumerType(string custumerCnpj)
         => !String.IsNullOrEmpty(custumerCnpj) ? "J" : "F";

        private string ReturnCorrectValue(string value, string valueOrigin)
         => !String.IsNullOrEmpty(value) ? Util.RemoveAccents(value) : Util.RemoveAccents(valueOrigin);
    }
}
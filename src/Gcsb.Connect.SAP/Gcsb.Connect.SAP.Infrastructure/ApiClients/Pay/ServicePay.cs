using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.Pay
{
    public class ServicePay : IServicePay
    {
        private readonly IService service;
        private readonly IMapper mapper;

        public ServicePay(IService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public List<Domain.PAY.Critical> Execute(DateTime dateStart, DateTime dateEnd)
        {
            var apiUrl = Environment.GetEnvironmentVariable("API_GW_URL");
            var request = new RestRequest("/api/PayConsulting/SAP", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());
            request.AddParameter("application / json", JsonConvert.SerializeObject(new { dateStart , dateEnd }), ParameterType.RequestBody);
            
           var response  = service.Execute<List<CriticalPay>>(apiUrl, request);            

            return mapper.Map<List<Domain.PAY.Critical>>(response);
        }

        public List<Domain.PAY.InvoicePayment> GetInvoicePayment(List<string> invoices)
        {
            var apiUrl = Environment.GetEnvironmentVariable("API_GW_URL");
            var request = new RestRequest("/api/PayConsulting/GetInvoicePayments", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());
            request.AddParameter("application / json", JsonConvert.SerializeObject(new { invoices }), ParameterType.RequestBody);

            var response = service.Execute<List<InvoicePaymentDto>>(apiUrl, request);

            return mapper.Map<List<Domain.PAY.InvoicePayment>>(response); ;
        }
    }
}

using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AvgOfferConsumption;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AvgOfferConsumption
{
    public class AvgOfferConsumptionUseCase : IAvgOfferConsumptionUseCase
    {
        private readonly IOutputPort<AvgOfferConsumptionOutput> outputPort;
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public AvgOfferConsumptionUseCase(IOutputPort<AvgOfferConsumptionOutput> outputPort, IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.outputPort = outputPort;
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public void Execute(AvgOfferConsumptionRequest request)
        {
            var avgConsumption = serviceInvoiceReadOnlyRepository.GetServices(
                s => s.PurchaseDate >= request.StartConsumptioPeriod
                    && s.PurchaseDate <= request.EndConsumptionPeriod
                    && s.OfferCode == request.OfferCode
                    && s.Activity != "Reduction"
                    && s.Activity != "Credits")
                .Select(s => s.GrandTotalRetailPrice).Average();
            outputPort.Standard(new AvgOfferConsumptionOutput() { AvgOfferConsumption = Math.Round(avgConsumption ?? 0, 2) });
        }
    }
}

using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class DigitalCertificateLaunchHandler : Handler
    {
        private readonly IDigitalCertificateRepository digitalCertificateRepository;

        public DigitalCertificateLaunchHandler(IDigitalCertificateRepository digitalCertificateRepository)
        {
            this.digitalCertificateRepository = digitalCertificateRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            var counterchargeDisputes = request.CounterchargeDisputesAdjustment.Where(w => w.TipoSubscricao.ToUpper() == "SAAS").ToList();
            var orderNumbers = counterchargeDisputes.Select(s => s.NumeroPedido.ToString()).ToList();
            var stores = request.CounterchargeDisputesAdjustment.Select(s => s.StoreAcronym).Distinct().ToList();
            var digitalCertificate = digitalCertificateRepository.GetCerficateStatusLicense(orderNumbers);

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var launches = new List<Launch>();
                var counterchargeDisputesbyStore = counterchargeDisputes.Where(w => w.StoreAcronym.Equals(store)).ToList();
                var certificateStatus = new List<string>() { "Emitido", "Revogado" };
                var fileAJULineCount = request.Lines.ContainsKey(storeType) ? request.Lines[storeType].Count : 0;
                var notEmittedPaid = GetLines(counterchargeDisputesbyStore.Where(w=> w.PaymentStatusType == PaymentStatusType.Pago).ToList(), digitalCertificate.Where(w=> !certificateStatus.Contains(w.Status)).ToList(), request.ServiceAccountingAccountNotEmittedPaid, request.DateFrom, request.DateTo, storeType, fileAJULineCount);
                var notEmittedNotPaid = GetLines(counterchargeDisputesbyStore.Where(w => w.PaymentStatusType != PaymentStatusType.Pago).ToList(), digitalCertificate.Where(w => !certificateStatus.Contains(w.Status)).ToList(), request.ServiceAccountingAccountNotEmittedNotPaid,request.DateFrom, request.DateTo, storeType, notEmittedPaid.Count());
                var emittedOrRevoke = GetLines(counterchargeDisputesbyStore, digitalCertificate.Where(w => certificateStatus.Contains(w.Status)).ToList(), request.ServiceAccountingAccountAdjusment, request.DateFrom, request.DateTo, storeType, notEmittedNotPaid.Count());

                launches.AddRange(notEmittedPaid);
                launches.AddRange(notEmittedNotPaid);
                launches.AddRange(emittedOrRevoke);

                request.AddLaunchs(storeType, launches);
            };

        }

        private List<Launch> GetLines(
        List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,
        List<Domain.DigitalCertificate.CertificateStatusLicense> certificateStatusLicenses,
        List<ServiceAccountingAccountAJU> accountingEntries,      
        DateTime launchDate,
        DateTime billingCycle,
        StoreType storeType,
        int qtdeLinhas = 0)
        {
            var activeTypes = new List<string>() { "Interest", "Fines", "Payment Credit", "Contractual Fine" };         

            return counterchargeDisputes
                  .Where(f => f.ValorContestado.HasValue && f.ValorContestado != 0 && f.MetodoPagamento != null && !activeTypes.Contains(f.TipoAtividade))                
                  .Join(certificateStatusLicenses, c => c.NumeroPedido, d => int.Parse(d.OrderNumber), (c, d) => new { c, d })
                  .Join(accountingEntries, c => c.c.FinancialAccount.FaturamentoAJU, a => a.FinancialAccount, (c, a) => new { c, a })
                  .GroupBy(g => new { g.c.c.FinancialAccount.FaturamentoAJU, g.c.c.MetodoPagamento, g.c.c.TipoDisputa, g.c.c.UF, g.a.Type, g.c.d.Status})
                  .Select((s) => new Launch(
                         qtdeLinhas,
                         launchDate,
                         s.Key.FaturamentoAJU,
                         s.Sum(m => Math.Abs(m.c.c.ValorContestado.Value)) / s.FirstOrDefault().c.d.LicenseNum,
                         Util.GetUF(s.Key.UF, storeType).InternalOrder,
                         billingCycle,
                         s.Key.UF,
                         s.FirstOrDefault().c.c.MetodoPagamento.RemoveAccents(),
                         s.Key.Type.GetAttributeOfType<EnumMemberAttribute>().Value,
                         s.Key.TipoDisputa == "Future Account" && (s.Key.Status == "Emitido"|| s.Key.Status == "Revogado") ? s.FirstOrDefault().a.AccountingAccount[1] : s.FirstOrDefault().a.AccountingAccount[0],
                         storeType)).ToList();
        }

    }
}


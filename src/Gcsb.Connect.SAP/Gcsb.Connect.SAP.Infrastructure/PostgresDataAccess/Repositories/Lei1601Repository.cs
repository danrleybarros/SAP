using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories.Lei1601;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.LEI1601;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class Lei1601Repository : ILei1601Repository
    {
        public IEnumerable<Launch> GetAll()
        {
            using var context = new Context();

            var paymentIdBoleto = context.File.Where(w => w.Type == TypeRegister.PAYMENTBOLETOTSV && w.InclusionDate.Date == DateTime.UtcNow.AddDays(-1).Date).Select(s => s.Id).ToList();
            var paymentIdCreditCard = context.File.Where(w => w.Type == TypeRegister.PAYMENTTSV && w.InclusionDate.Date == DateTime.UtcNow.AddDays(-1).Date).Select(s => s.Id).ToList();

            var paymentBoleto = GetPaymentBoletos(paymentIdBoleto);            
            var paymentCreditCard = GetPaymentCredit(paymentIdCreditCard);

            return paymentBoleto.Union(paymentCreditCard).ToList();
        }

        private List<Launch> GetPaymentBoletos(List<Guid> ids)
        {
            using var context = new Context();

            var dataBoleto = context.PaymentBoleto.Include(i => i.Invoice).Where(w => ids.Contains(w.IdFile));

            return dataBoleto
                .GroupBy(g => new { g.TransactionDate, g.CodigoBanco, g.NomeBanco, g.Invoice.AffiliateCode })
                .Select(s => new Launch
                (
                    s.FirstOrDefault().IdFile,
                    s.FirstOrDefault().Invoice.CompanyCode,
                    s.Key.AffiliateCode,
                    s.Key.TransactionDate.Value,
                    s.Sum(sum => sum.TransactionAmount.Value),
                    s.Key.CodigoBanco + s.Key.NomeBanco,
                    Domain.Lei1601.PaymentMethod.Boleto,
                    s.Key.CodigoBanco
                )).ToList();
        }

        private List<Launch> GetPaymentCredit(List<Guid> ids)
        {
            using var context = new Context();

            var data = context.PaymentFeedCreditCard.Include(i => i.Invoice).Where(w => ids.Contains(w.IdFile)).ToList();

            return data
                .GroupBy(g => new { g.TransactionDate?.Date, g.AcquirerEntity, g.CardBrand, g.Invoice.AffiliateCode })
                .Select(s => new Launch
                (
                    s.FirstOrDefault().IdFile,
                    s.FirstOrDefault().Invoice.CompanyCode,
                    s.Key.AffiliateCode,
                    s.Key.Date,
                    s.Sum(sum => sum.TransactionAmount.Value),
                    $"{s.Key.AcquirerEntity ?? string.Empty}{(s.Key.CardBrand != null ? (CardLabel)s.Key.CardBrand : string.Empty)}",
                    Domain.Lei1601.PaymentMethod.Credit,
                    s.Key.AcquirerEntity
                )).ToList();
        }
    }
}

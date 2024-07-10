using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV.Handler
{
    public class GetContentCSVHandler : Handler<AccountExportCSVRequest>
    {
        public override void ProcessRequest(AccountExportCSVRequest request)
        {
            request.AddLog("GetContentCSVHandler", "Content CSV in string builder");

            request.ContentCSV = new StringBuilder();

            request.ContentCSV.AppendLine("Loja;CFJuros;CCDebitoJuros;CCCreditoJuros;CCDebitoContestacaoFaturanaopagaJuros;CCCreditoContestacaoFaturanaopagaJuros;CCDebitoContestacaoFaturapagaJuros;CCCreditoContestacaoFaturapagaJuros;CCDebitoEstimativadeCicloJuros;CCCreditoEstimativadeCicloJuros;CFFaturadoEstornoContestacaoJuros;CCDebitoEstCreditoFuturoValorNaoUtilizadoJuros;CCCreditoEstCreditoFuturoValorNaoUtilizadoJuros;CCDebitoEstCreditoFuturoValorUtilizadoJuros;CCCreditoEstCreditoFuturoValorUtilizadoJuros;CCDebitoEstBoletoRetificadoJuros;CCCreditoEstBoletoRetificadoJuros;CFDebitoConcedidoJuros;CCDebitoDebitoConcedidoJuros;CCCreditoDebitoConcedidoJuros;CFMulta;CCDebitoMulta;CCCreditoMulta;CCDebitoContestacaoFaturanaopagaMulta;CCCreditoContestacaoFaturanaopagaMulta;CCDebitoContestacaoFaturapagaMulta;CCCreditoContestacaoFaturapagaMulta;CCDebitoEstimativadeCicloMulta;CCCreditoEstimativadeCicloMulta;CFFaturadoEstornoContestacaoMulta;CCDebitoEstCreditoFuturoValorNaoUtilizadoMulta;CCCreditoEstCreditoFuturoValorNaoUtilizadoMulta;CCDebitoEstCreditoFuturoValorUtilizadoMulta;CCCreditoEstCreditoFuturoValorUtilizadoMulta;CCDebitoEstBoletoRetificadoMulta;CCCreditoEstBoletoRetificadoMulta;CFDebitoConcedidoMulta;CCDebitoDebitoConcedidoMulta;CCCreditoDebitoConcedidoMulta");

            if (request.InterestAndFineFinancialAccounts.Count > 0)
            {
                foreach (var line in request.InterestAndFineFinancialAccounts)
                {
                    request.ContentCSV.AppendLine(
                        (line.Store.ToString() == "TLF2" ? "CLOUDCO" : line.Store.ToString()) + ";" +
                        line.Interest.FinancialAccount + ";" +
                        line.Interest.InterestOrFine.Debit + ";" +
                        line.Interest.InterestOrFine.Credit + ";" +
                        line.Interest.UnpaidInvoice.Debit + ";" +
                        line.Interest.UnpaidInvoice.Credit + ";" +
                        line.Interest.PaidInvoice.Debit + ";" +
                        line.Interest.PaidInvoice.Credit + ";" +
                        line.Interest.CycleEstimate.Debit + ";" +
                        line.Interest.CycleEstimate.Credit + ";" +
                        line.Interest.BilledCounterchargeChargeback + ";" +
                        line.Interest.ChargebackFutureCreditUnusedValue.Debit + ";" +
                        line.Interest.ChargebackFutureCreditUnusedValue.Credit + ";" +
                        line.Interest.ChargebackFutureCreditUsedValue.Debit + ";" +
                        line.Interest.ChargebackFutureCreditUsedValue.Credit + ";" +
                        line.Interest.ChargebackRectifiedBoleto.Debit + ";" +
                        line.Interest.ChargebackRectifiedBoleto.Credit + ";" +
                        line.Interest.GrantedDebit + ";" +
                        line.Interest.GrantedDebitAccounting.Debit + ";" +
                        line.Interest.GrantedDebitAccounting.Credit + ";" +
                        line.Fine.FinancialAccount + ";" +
                        line.Fine.InterestOrFine.Debit + ";" +
                        line.Fine.InterestOrFine.Credit + ";" +
                        line.Fine.UnpaidInvoice.Debit + ";" +
                        line.Fine.UnpaidInvoice.Credit + ";" +
                        line.Fine.PaidInvoice.Debit + ";" +
                        line.Fine.PaidInvoice.Credit + ";" +
                        line.Fine.CycleEstimate.Debit + ";" +
                        line.Fine.CycleEstimate.Credit + ";" +
                        line.Fine.BilledCounterchargeChargeback + ";" +
                        line.Fine.ChargebackFutureCreditUnusedValue.Debit + ";" +
                        line.Fine.ChargebackFutureCreditUnusedValue.Credit + ";" +
                        line.Fine.ChargebackFutureCreditUsedValue.Debit + ";" +
                        line.Fine.ChargebackFutureCreditUsedValue.Credit + ";" +
                        line.Fine.ChargebackRectifiedBoleto.Debit + ";" +
                        line.Fine.ChargebackRectifiedBoleto.Credit + ";" +
                        line.Fine.GrantedDebit + ";" +
                        line.Fine.GrantedDebitAccounting.Debit + ";" +
                        line.Fine.GrantedDebitAccounting.Credit
                        );
                }
            }

            Sucessor?.ProcessRequest(request);
        }
    }
}

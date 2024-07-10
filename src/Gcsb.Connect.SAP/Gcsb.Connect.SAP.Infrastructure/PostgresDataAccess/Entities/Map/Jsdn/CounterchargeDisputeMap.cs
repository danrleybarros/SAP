using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map.Jsdn
{
    public class CounterchargeDisputeMap : IEntityTypeConfiguration<CounterchargeDispute>
    {
        public void Configure(EntityTypeBuilder<CounterchargeDispute> builder) 
        {
            var schema = Environment.GetEnvironmentVariable("JSDN_SCHEMA");

            builder.ToView("countercharge_dispute", schema);

            builder.Property(e => e.TipoSubscricao)
                .HasColumnName("subscription_type")
                .HasMaxLength(256);

            builder.Property(e => e.DataMovimentacao)
                .HasColumnName("movement_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.AReceber)
                .HasColumnName("receivable")
                .HasMaxLength(256);

            builder.Property(e => e.TipoTransacao)
                .HasColumnName("transaction_type")
                .HasMaxLength(256);

            builder.Property(e => e.UF)
                .HasColumnName("uf")
                .HasMaxLength(256);

            builder.Property(e => e.Ciclo)
                .HasColumnName("cycle")
                .HasMaxLength(256);

            builder.Property(e => e.ReferenciaCicloFaturamento)
                .HasColumnName("billing_cycle_reference")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.CodigoEmpresa)
                .HasColumnName("company_code")
                .HasMaxLength(256);

            builder.Property(e => e.FlagTipoFaturamento)
                .HasColumnName("flag_billing_type")
                .HasMaxLength(256);

            builder.Property(e => e.ValorTransacao)
                .HasColumnName("transaction_amount");

            builder.Property(e => e.NumeroFatura)
                .HasColumnName("invoice_number")
                .HasMaxLength(256);

            builder.Property(e => e.CustomerCode)
                .HasColumnName("customer_id");

            builder.Property(e => e.CodigoFranquia)
                .HasColumnName("store_code")
                .HasMaxLength(256);

            builder.Property(e => e.CNPJ)
                .HasColumnName("cnpj")
                .HasMaxLength(256);

            builder.Property(e => e.CPF)
                .HasColumnName("cpf")
                .HasMaxLength(256);

            builder.Property(e => e.NomedaEmpresadoCliente)
                .HasColumnName("customers_company_name")
                .HasMaxLength(256);

            builder.Property(e => e.DataVencimento)
                .HasColumnName("due_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.DataCriacaoFatura)
                .HasColumnName("invoice_creation_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.DataIniciodoCiclo)
                .HasColumnName("cycle_start_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.SaldoTotalGeral)
                .HasColumnName("overall_total_balance");

            builder.Property(e => e.DataFimCiclo)
                .HasColumnName("cycle_end_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.DataCriacaoPedido)
                .HasColumnName("order_creation_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.StatusContadoCliente)
                .HasColumnName("customer_account_status")
                .HasMaxLength(256);

            builder.Property(e => e.InadimplenciaPremeditada)
                .HasColumnName("premeditated_default")
                .HasMaxLength(256);

            builder.Property(e => e.Produto)
                .HasColumnName("product")
                .HasMaxLength(256);

            builder.Property(e => e.StatusPagamento)
                .HasColumnName("payment_status")
                .HasMaxLength(256);

            builder.Property(e => e.TipoDisputa)
                .HasColumnName("dispute_type")
                .HasMaxLength(256);

            builder.Property(e => e.DataConcessaoCredito)
                .HasColumnName("credit_grant_date_time")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.NumeroPedido)
                .HasColumnName("orders_number");

            builder.Property(e => e.MotivoCredito)
                .HasColumnName("credit_reason")
                .HasMaxLength(256);

            builder.Property(e => e.Nota)
                .HasColumnName("note")
                .HasMaxLength(256);

            builder.Property(e => e.LoginUsuario)
                .HasColumnName("user_login")
                .HasMaxLength(256);

            builder.Property(e => e.DataCortedoCiclo)
                .HasColumnName("cycle_cut_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.Complemento)
                .HasColumnName("complement")
                .HasMaxLength(256);

            builder.Property(e => e.ValorContestado)
                .HasColumnName("contested_value");

            builder.Property(e => e.CentrodeCusto)
                .HasColumnName("cost_center")
                .HasMaxLength(256);

            builder.Property(e => e.CicloContestado)
                .HasColumnName("contested_cycle")
                .HasMaxLength(256);

            builder.Property(e => e.LocaldeTrabalho)
                .HasColumnName("place_of_business")
                .HasMaxLength(256);

            builder.Property(e => e.DataEmissaoBoletoRetificado)
                .HasColumnName("rectified_boleto_issue_date")
                .HasColumnType("timestamp with time zone");

            builder.Property(e => e.CodigoServico)
                .HasColumnName("service_code")
                .HasMaxLength(256);

            builder.Property(e => e.ValorContestacaoItem)
                .HasColumnName("countercharge_amount_in_item");

            builder.Property(e => e.EnderecoCobranca)
                .HasColumnName("billing_address")
                .HasMaxLength(1000);

            builder.Property(e => e.MetodoPagamento)
                .HasColumnName("payment_method")
                .HasMaxLength(256);

            builder.Property(e => e.StoreAcronym)
                .HasColumnName("store_acronym")
                .HasMaxLength(256);

            builder.Property(e => e.ProviderCompanyAcronym)
            .HasColumnName("provider_company_acronym")
            .HasMaxLength(256);

            builder.Property(e => e.TipoAtividade)
                .HasColumnName("activity_type")
                .HasMaxLength(256);

            builder.Property(e => e.CicloNulo)
                .HasColumnName("CycleIsNull");

            builder.HasNoKey();
        }
    }
}

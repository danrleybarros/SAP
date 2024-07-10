using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Npgsql;
using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories.Jsdn
{
    public class JsdnRepository : IJsdnRepository
    {
        private readonly IMapper mapper;
        const string quote = "\"";

        public JsdnRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<CounterchargeDispute> GetAllCounterchargeDispute(DateTime from, DateTime to)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetAllCounterchargeDisputeByCycle(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery,
                    new NpgsqlParameter("datefrom", from),
                    new NpgsqlParameter("dateto", to))
                    .ToList();

                return mapper.Map<List<CounterchargeDispute>>(result);
            }
        }

        public List<CounterchargeDispute> GetAllCounterchargeDisputeBilling(DateTime from, DateTime to)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetAllCounterchargeDisputeBillingByCycle(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery,
                    new NpgsqlParameter("datefrom", from),
                    new NpgsqlParameter("dateto", to))
                    .ToList();

                return mapper.Map<List<CounterchargeDispute>>(result);
            }
        }

        public List<CounterchargeDispute> GetCounterchargeDispute(DateTime from, DateTime to)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetCounterchargeDisputeByCycle(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery,
                    new NpgsqlParameter("datefrom", from),
                    new NpgsqlParameter("dateto", to))
                    .ToList();

                return mapper.Map<List<CounterchargeDispute>>(result);
            }   
        }

        public List<CounterchargeDispute> GetCounterchargeDisputeByInvoice(List<string> invoicesNumber)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetCounterchargeDisputeByInvoices(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery, new NpgsqlParameter("invoicesNumber", invoicesNumber.ToArray()))
                    .ToList(); 

                return mapper.Map<List<CounterchargeDispute>>(result);
            }
        }

        public List<CounterchargeDispute> GetCounterchargeDisputeByInvoiceAndTransactionType(List<string> invoicesNumber, string transactionType)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetCounterchargeDisputeByInvoicesAndTransactionType(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery, 
                    new NpgsqlParameter("invoicesNumber", invoicesNumber.ToArray()),
                    new NpgsqlParameter("transactionType", transactionType))
                    .ToList();

                return mapper.Map<List<CounterchargeDispute>>(result);
            }
        }

        public List<CounterchargeDispute> GetCounterChargeDisputeByCycle(DateTime from, DateTime to)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetCounterchargeByCycle(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.CounterchargeDispute>()
                    .FromSqlRaw(strQuery,
                    new NpgsqlParameter("datefrom", from),
                    new NpgsqlParameter("dateto", to))
                    .ToList();

                return mapper.Map<List<CounterchargeDispute>>(result);
            }
        }

        public List<PaymentReport> GetPaymentReportsByInvoices(List<string> invoicesNumber)
        {
            var schemma = Environment.GetEnvironmentVariable("JSDN_SCHEMA");
            var strQuery = GetPaymentReportsByInvoicesQuery(schemma);

            using (var context = new JsdnContext())
            {
                var result = context.Set<Entities.PaymentReport>()
                    .FromSqlRaw(strQuery, new NpgsqlParameter("invoicesNumber", invoicesNumber.ToArray()))
                    .ToList();

                return mapper.Map<List<PaymentReport>>(result);
            }
        }

        public string GetAllCounterchargeDisputeByCycle(string schemma)
            => $@"{ CounterchargeDispute(schemma) }
            where DATE(credit_grant_date_time) between @datefrom and @dateto
            and transaction_type = 'Adjustment' 
            and invoice_number is not null
            and contested_value is not null
            and contested_value::numeric != 0;";

        public string GetCounterchargeByCycle(string schemma)
          => $@"{ CounterchargeDispute(schemma) }
            where DATE(movement_date) between @datefrom and @dateto";          

        public string GetAllCounterchargeDisputeBillingByCycle(string schemma)
            => $@"{ CounterchargeDispute(schemma) }
            where DATE(movement_date) between @datefrom and @dateto
            and transaction_type = 'Billing' 
            and invoice_number is not null
            and contested_value is not null
            and contested_value::numeric != 0;";

        public string GetCounterchargeDisputeByCycle(string schemma)
            => $@"{ CounterchargeDispute(schemma) }
            where DATE(credit_grant_date_time) between @datefrom and @dateto 
            and dispute_type = 'Rectified Boleto' 
            and contested_value is not null;";

        public string GetCounterchargeDisputeByInvoices(string schemma)
            => $@"{ CounterchargeDispute(schemma) }
            where invoice_number = ANY(@invoicesNumber) 
            and contested_value is not null;";

        public string GetCounterchargeDisputeByInvoicesAndTransactionType(string schemma)
            => $@"{ CounterchargeDispute(schemma) }
            where invoice_number = ANY(@invoicesNumber) 
            and lower(transaction_type) = @transactionType
            and invoice_number is not null
            and contested_value is not null;";

        public string CounterchargeDispute(string schemma)
            => $@"SELECT subscription_type, 
            movement_date, 
            receivable, 
            transaction_type, 
            uf, 
            cycle,  
            TO_TIMESTAMP(
            case 
	            when (billing_cycle_reference != '' and billing_cycle_reference is not null) then concat('01-',billing_cycle_reference) 
	            else right(concat('0001/01', replace(contested_cycle, '/', ''), '/01'), 10) 
            end, 
            case 
	            when (billing_cycle_reference != '' and billing_cycle_reference is not null) then 'dd-MM-yyyy HH24:MI:SS' 
	            else 'yyyy/MM/dd HH24:MI:SS' 
            end
            ) as billing_cycle_reference,
            company_code, 
            flag_billing_type, 
            transaction_amount::numeric as transaction_amount, 
            invoice_number, 
            cast(customer_id as integer) as customer_id, 
            store_code, 
            cnpj, 
            cpf, 
            customers_company_name, 
            coalesce(due_date, '0001/01/01') due_date, 
            coalesce(invoice_creation_date, '0001/01/01') invoice_creation_date, 
            coalesce(cycle_start_date, '0001/01/01') cycle_start_date, 
            overall_total_balance::numeric as overall_total_balance, 
            coalesce(cycle_end_date, '0001/01/01') cycle_end_date, 
            coalesce(order_creation_date, '0001/01/01') order_creation_date, 
            customer_account_status, 
            premeditated_default, 
            product, 
            payment_status, 
            dispute_type, 
            credit_grant_date_time, 
            cast(orders_number as integer) as orders_number, 
            credit_reason, 
            note, 
            user_login, 
            coalesce(cycle_cut_date, '0001/01/01') cycle_cut_date,
            complement, 
            contested_value::numeric as contested_value, 
            cost_center, 
            contested_cycle, 
            place_of_business, 
            rectified_boleto_issue_date, 
            service_code, 
            round(countercharge_amount_in_item::numeric, 2) as countercharge_amount_in_item, 
            billing_address, 
            payment_method ,
            store_acronym,
            service_provider_company_acronym as provider_company_acronym,
            activity_type,
            billing_cycle_reference is null as CycleIsNull
            FROM {quote}{schemma}{quote}.countercharge_dispute";

        public string GetPaymentReportsByInvoicesQuery(string schemma)
            => $@"select 
                product_code  				as service_code,
                product_name				as service_name,
                store_acronym				as store_acronym,
                company_provider_acronym 	as company_provider_acronym,
                customer_id					as customer_code,
                invoice_number				as invoice_number,	
                bank_code					as bank_code,
                payment_date				as payment_date,
                written_down_product_value	as payment_value,
                total_payment_amount        as total_payment_value
                from {quote}{schemma}{quote}.payment_reports
            where language_code = 'pt_PT'
            and invoice_number = any(@invoicesNumber);";
    }
}

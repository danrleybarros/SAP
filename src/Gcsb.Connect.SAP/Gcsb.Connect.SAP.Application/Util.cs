using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Domain.SAP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gcsb.Connect.SAP.Application
{
    public static class Util
    {
        public static string GetUFByState(string ufFullName, StoreType storeType)
            => GetUF(ufFullName, storeType).Uf;

        public static UFComp GetUF(string ufFullName, StoreType storeType)
        {
            var InternalOrderPrefix = storeType switch
            {
                StoreType.TLF2 => "C",
                StoreType.TBRA => "T",
                StoreType.IOTCo => "E",
                _ => ""
            };

            ufFullName = RemoveAccents(ufFullName);

            return ufFullName.ToLower() switch
            {
                "acre" or "ac" => new UFComp("AC", "ACRE", $"{InternalOrderPrefix}2983AC"),
                "alagoas" or "al" => new UFComp("AL", "Alagoas", $"{InternalOrderPrefix}2934AL"),
                "amapa" or "ap" => new UFComp("AP", "Amapá", $"{InternalOrderPrefix}2963AP"),
                "amazonas" or "am" => new UFComp("AM", "Amazonas", $"{InternalOrderPrefix}2961AM"),
                "bahia" or "ba" => new UFComp("BA", "Bahia", $"{InternalOrderPrefix}2921BA"),
                "ceara" or "ce" => new UFComp("CE", "Ceará", $"{InternalOrderPrefix}2937CE"),
                "distrito federal" or "federal district" or "df" => new UFComp("DF", "Distrito Federal", $"{InternalOrderPrefix}2940DF"),
                "espirito santo" or "es" => new UFComp("ES", "Espírito Santo", $"{InternalOrderPrefix}2918ES"),
                "goias" or "go" => new UFComp("GO", "Goiás", $"{InternalOrderPrefix}2950GO"),
                "maranhao" or "ma" => new UFComp("MA", "Maranhão", $"{InternalOrderPrefix}2964MA"),
                "mato grosso" or "mt" => new UFComp("MT", "Mato Grosso", $"{InternalOrderPrefix}2980MT"),
                "mato grosso do sul" or "ms" => new UFComp("MS", "Mato Grosso do Sul", $"{InternalOrderPrefix}2981MS"),
                "minas gerais" or "mg" => new UFComp("MG", "Minas Gerais", $"{InternalOrderPrefix}2985MN"),
                "para" or "pa" => new UFComp("PA", "Pará", $"{InternalOrderPrefix}2960PA"),
                "paraiba" or "pb" => new UFComp("PB", "Paraíba", $"{InternalOrderPrefix}2938PB"),
                "parana" or "pr" => new UFComp("PR", "Paraná", $"{InternalOrderPrefix}2930PR"),
                "pernambuco" or "pe" => new UFComp("PE", "Pernambuco", $"{InternalOrderPrefix}2935PE"),
                "piaui" or "pi" => new UFComp("PI", "Piauí", $"{InternalOrderPrefix}2936PI"),
                "rio de janeiro" or "rj" => new UFComp("RJ", "Rio de Janeiro", $"{InternalOrderPrefix}2917RJ"),
                "rio grande do norte" or "rn" => new UFComp("RN", "Rio Grande do Norte", $"{InternalOrderPrefix}2939RN"),
                "rio grande do sul" or "rs" => new UFComp("RS", "Rio Grande do Sul", $"{InternalOrderPrefix}2913RS"),
                "rondonia" or "ro" => new UFComp("RO", "Rondônia", $"{InternalOrderPrefix}2982RO"),
                "roraima" or "rr" => new UFComp("RR", "Roraima", $"{InternalOrderPrefix}2962RR"),
                "santa catarina" or "sc" => new UFComp("SC", "Santa Catarina", $"{InternalOrderPrefix}2931SC"),
                "sao paulo" or "sp" => new UFComp("SP", "São Paulo", $"{InternalOrderPrefix}2929SP"),
                "sergipe" or "se" => new UFComp("SE", "Sergipe", $"{InternalOrderPrefix}2922SE"),
                "tocantins" or "to" => new UFComp("TO", "Tocantins", $"{InternalOrderPrefix}2951TO"),
                _ => null,
            };
        }

        public static string RemoveAccents(this string text)
        {
            if (text == null)
                return "";
            return new string(text.Normalize(NormalizationForm.FormD).Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark).ToArray());
        }

        public static string GetFileName(string fileName, List<ServiceInvoice> serviceInvoices, string extension)
            => $"{fileName}{serviceInvoices.Where(w => w.DueDate != null).Max(m => m.CycleReference).Value.ToString("MMyyyy")}.{extension}";

        public static DateTime GetDateProcessingFile(string fileName)
        {
            DateTime dateProcessing;
            var culture = CultureInfo.CreateSpecificCulture("pt-br");

            string dateFile = Regex.Replace(fileName, "[a-z_.A-Z]", string.Empty);

            if (DateTime.TryParse(dateFile, culture, DateTimeStyles.None, out dateProcessing))
                return dateProcessing;
            else
                throw new ArgumentOutOfRangeException();
        }

        public static string GetCustomerCodeWithTenDigits(string customerCode)
        {
            if (customerCode.Length == 10)
                return customerCode;

            var newCustomerCode = $"7{ customerCode.PadLeft(9, '0') }";
            return newCustomerCode;
        }

        public static string WithTenDigits(this string customerCode)
        {
            if (customerCode.Length == 10)
                return customerCode;

            var newCustomerCode = $"7{customerCode.PadLeft(9, '0')}";
            return newCustomerCode;
        }

        public static decimal GetLaunchAmount(bool isDescont, string serviceType, decimal sumGrandTotalRetailPrice, decimal sumTotalRetailPriceDiscountAmount, decimal sumTotalRetailPriceWithTaxesWithoutDiscount, bool isRound = true)
        {
            if (isDescont)
            {
                if (serviceType.ToUpper().Equals("SAAS"))
                    return isRound ? Math.Round(sumTotalRetailPriceDiscountAmount, 2) : sumTotalRetailPriceDiscountAmount;
                else
                    return isRound ? Math.Abs(Math.Round(sumGrandTotalRetailPrice - sumTotalRetailPriceWithTaxesWithoutDiscount, 2)) :
                        Math.Abs(sumGrandTotalRetailPrice - sumTotalRetailPriceWithTaxesWithoutDiscount);
            }
            else
            {
                var discount = GetLaunchAmount(true, serviceType, sumGrandTotalRetailPrice, sumTotalRetailPriceDiscountAmount, sumTotalRetailPriceWithTaxesWithoutDiscount, true);

                return isRound ? Math.Round(sumGrandTotalRetailPrice + discount, 2) :
                     sumGrandTotalRetailPrice + discount;
            }
        }
    }
}

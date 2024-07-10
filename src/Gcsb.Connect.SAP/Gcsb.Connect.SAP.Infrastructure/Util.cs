using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Gcsb.Connect.SAP.Infrastructure
{
    public static class Util
    {
        public static DateTime? ConvertDateBill(string date)
        {
            if (string.IsNullOrEmpty(date)) return null;
            if (date.Length < 7) throw new ArgumentOutOfRangeException();

            // Caso data informada venha no padrao mês/ano, adicionamos 01 para formar um datetime válido;
            if (date.Length == 7)
                date = date.Contains("/") ? $"01/{date}" : $"01-{date}";

            return DateTime.Parse(date, new System.Globalization.CultureInfo("pt-BR"));
        }

        public static void CreateDirectory(string path)
        {
            if (path != null && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
		}
    }
}

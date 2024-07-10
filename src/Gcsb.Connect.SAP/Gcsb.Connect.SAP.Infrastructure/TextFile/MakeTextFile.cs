using System.Text;
using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class MakeTextFile : IMakeTextFile
    {
        public StringBuilder ProcessRequestWithSpace<T>(T model)
        {
            var obj = model.GetType().GetProperties().ToList().Where(p => !p.GetCustomAttributes(false).Any(a => a.GetType().Name.Equals("NotMappedAttribute"))).ToList();
            var strBuilder = new StringBuilder();

            obj.ForEach(f =>
            {
                string value = f.GetValue(model) == null ? "" : f.GetValue(model).ToString();

                if (string.IsNullOrEmpty(value))
                {
                    var attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Contains("MaxLength")).FirstOrDefault();

                    for (var lintCont = 0; lintCont < ((MaxLengthAttribute)attr).Length; lintCont++)
                        strBuilder.Append(" ");
                }
                else
                {
                    var attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Equals("FormatAttribute")).FirstOrDefault();

                    if (attr != null)
                    {
                        strBuilder.AppendFormat(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), ((Domain.FormatAttribute)attr).Format, f.GetValue(model));
                        return;
                    }

                    attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Contains("MaxLength")).FirstOrDefault();
                    if (attr != null)
                    {
                        strBuilder.Append(value);
                        for (var lintCont = 0; lintCont < ((MaxLengthAttribute)attr).Length - value.Length; lintCont++)
                            strBuilder.Append(" ");
                    }

                    else
                    {
                        strBuilder.Append($"{value}");
                    }

                }

            });

            return strBuilder;
        }

        public StringBuilder ProcessRequestWithoutSpace<T>(T model)
        {
            var obj = model.GetType().GetProperties().ToList().Where(p => !p.GetCustomAttributes(false).Any(a => a.GetType().Name.Equals("NotMappedAttribute"))).ToList();
            var strBuilder = new StringBuilder();

            obj.ForEach(f =>
            {
                string value = f.GetValue(model) == null ? "" : f.GetValue(model).ToString();

                if (string.IsNullOrEmpty(value))
                {
                    var attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Contains("MaxLength")).FirstOrDefault();

                    for (var lintCont = 0; lintCont < ((MaxLengthAttribute)attr).Length; lintCont++)
                        strBuilder.Append("");
                }
                else
                {
                    var attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Equals("FormatAttribute")).FirstOrDefault();

                    if (attr != null)
                    {
                        strBuilder.AppendFormat(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), ((Domain.FormatAttribute)attr).Format, f.GetValue(model));
                        return;
                    }

                    attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Contains("MaxLength")).FirstOrDefault();
                    if (attr != null)
                    {
                        strBuilder.Append(value);
                        for (var lintCont = 0; lintCont < ((MaxLengthAttribute)attr).Length - value.Length; lintCont++)
                            strBuilder.Append("");
                    }
                    else
                    {
                        strBuilder.Append($"{value}");
                    }
                }
            });

            return strBuilder;
        }

        public StringBuilder ProcessRequestWithComma<T>(T model)
        {
            var obj = model.GetType().GetProperties().ToList().Where(p => !p.GetCustomAttributes(false).Any(a => a.GetType().Name.Equals("NotMappedAttribute"))).ToList();
            var strBuilder = new StringBuilder();

            obj.ForEach(f =>
            {
                string value = f.GetValue(model) == null ? "" : f.GetValue(model).ToString();

                if (string.IsNullOrEmpty(value))
                {
                    strBuilder.Append(';');
                }
                else
                {
                    var attr = f.GetCustomAttributes(false).Where(w => w.GetType().Name.Equals("FormatAttribute")).FirstOrDefault();

                    if (attr != null)
                    {
                        strBuilder.AppendFormat(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), $"{((Domain.FormatAttribute)attr).Format};", f.GetValue(model));
                        return;
                    }
                    else
                    {
                        strBuilder.Append($"{value};");
                    }
                }
            });

            return strBuilder;
        }

        public void Execute(string str, string strPath)
        {
            if (!File.Exists(strPath))
            {
                var loStream = File.CreateText(strPath);
                loStream.Close();
            }

            File.WriteAllText(strPath, str);
        }
    }
}

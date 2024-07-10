using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Domain
{
    public static class Util
    {
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        public static DateTime LastDayOfThePreviousMonth(Invoice invoice)
        {
            var dateLessMonth = invoice.InvoiceCreationDate.Value.AddMonths(-1);
            var lastDay = DateTime.DaysInMonth(dateLessMonth.Year, dateLessMonth.Month);

            return new DateTime(dateLessMonth.Year, dateLessMonth.Month, lastDay);
        }

        public static T ToEnum<T>(string str)
        {
            var enumType = typeof(T);

            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

                if (enumMemberAttribute.Value.ToUpper().Equals(str.ToUpper())) return (T)Enum.Parse(enumType, name, true);
            }

            return default;
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static List<UploadTypeDto.UploadTypeDto> GetAllUploadType()
        {

            var uploadTypes = new List<UploadTypeDto.UploadTypeDto>();

            var enumType = typeof(UploadTypeEnum);

            foreach (string name in Enum.GetNames(enumType))
            {
                Enum.TryParse(name, out UploadTypeEnum resource);

                var memberData = enumType.GetMember(name);

                var value = name;
                var text = (memberData[0].GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute).Description;
                
                var uploadType = new UploadTypeDto.UploadTypeDto(value, text);

                uploadTypes.Add(uploadType);
            }

            return uploadTypes;

        }

        public static StoreType ToStoreType(this string store)
            => ToEnum<StoreType>(store);
    }
}

using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Tests
{
    public static class Util
    {
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        internal static string GetUFByState(string stateOrProvince)
        {
            throw new NotImplementedException();
        }
    }
}

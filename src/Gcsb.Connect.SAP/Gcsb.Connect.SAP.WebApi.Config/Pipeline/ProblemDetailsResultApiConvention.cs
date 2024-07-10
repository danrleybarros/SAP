using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Pipeline
{
    /// <summary>
    ///     Apply <see cref="ProblemDetailsResultAttribute" /> to all Api controllers
    /// </summary>
    public class ProblemDetailsResultApiConvention : ApiConventionBase
    {
        protected override void ApplyControllerConvention(ControllerModel controller)
        {
            controller.Filters.Add(new ProblemDetailsResultAttribute());
        }
    }
}

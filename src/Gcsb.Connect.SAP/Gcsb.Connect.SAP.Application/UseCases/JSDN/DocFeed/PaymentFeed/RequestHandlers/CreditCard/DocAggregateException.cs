using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class DocAggregateException : AggregateException
    {
        public DocAggregateException(IEnumerable<DocValidationException> innerExceptions) : base(innerExceptions)
        {
        }
    }
}

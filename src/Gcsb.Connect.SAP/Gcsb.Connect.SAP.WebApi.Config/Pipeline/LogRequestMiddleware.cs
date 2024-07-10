﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Pipeline
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            using (LogContext.PushProperty("RequestId", context.TraceIdentifier))
            {
                Exception exception = null;
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    throw;
                }
                finally
                {
                    Log.Logger.Information(exception, "Request: {Url}", request.GetEncodedUrl());
                }
            }
        }
    }
}

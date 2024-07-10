using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Caching;
using Polly.Caching.Memory;
using Polly.Extensions.Http;
using Polly.Registry;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class ServiceCollectionExtensions
    {
        public static Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> DangerousAcceptAnyServerCertificateValidator { get; }

        public static IServiceCollection AddHttpClientServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAsyncCacheProvider, MemoryCacheProvider>();
            services.AddPolicyRegistry();
            services.AddMemoryCache();          
            services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));

            var JsdnUrl = Environment.GetEnvironmentVariable("JSDN_URLV1");

            services.AddHttpClient<Application.Repositories.IJsdnService, Infrastructure.ApiClients.JsdnServices.JsdnClient>(client =>
            {
                client.BaseAddress = new Uri(JsdnUrl);
                client.Timeout = TimeSpan.FromSeconds(20);
            })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; },
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                })
                .AddPolicyHandlerFromRegistry(PolicySelector)
                .SetHandlerLifetime(TimeSpan.FromMinutes(2))
                .AddPolicyHandler(GetRetryPolicy());


            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
              .HandleTransientHttpError()
              .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
              .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        }

        private static IAsyncPolicy<HttpResponseMessage> PolicySelector(IReadOnlyPolicyRegistry<string> policyRegistry,
         HttpRequestMessage httpRequestMessage)
        {
            // you could have some logic to select the right policy
            // see https://nodogmablog.bryanhogan.net/2018/07/polly-httpclientfactory-and-the-policy-registry-choosing-the-right-policy-based-on-the-http-request/
            return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("CachingPolicy");
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
        }
    }
}

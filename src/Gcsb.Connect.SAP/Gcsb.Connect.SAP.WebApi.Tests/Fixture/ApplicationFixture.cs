using Autofac;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Gcsb.Connect.SAP.WebApi.Tests.Fixture
{
    public class ApplicationFixture
    {
        public IContainer Container { get; private set; }

        public ApplicationFixture()
        {

            if (Environment.GetEnvironmentVariable("JSDN_URLV1") == null)
                Environment.SetEnvironmentVariable("JSDN_URLV1", "https://predev-admtelefonica.gcsb.com.br/api/1.0");

            var builder = new ContainerBuilder();

            builder.RegisterInstance<HttpClient>(new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; },
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("JSDN_URLV1"))
            });

            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.Modules.WebApiModule>();
            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();

            builder.RegisterType<CustomerPresenter>().As<IOutputPort<List<ConsumptionOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PaymentFeedPresenter>().As<IOutputPort<List<PaymentFeedOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomerServicesPresenter>().As<IOutputPort<List<CustomerService>>>().AsSelf().InstancePerLifetimeScope();

            Container = builder.Build();
        }
    }
}

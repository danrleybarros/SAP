using Autofac;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices
{
    public class InMemoryModule : Autofac.Module
    {
        public InMemoryModule()
        {
            Consumers = new List<Type>();
        }
        public InMemoryModule(Action<List<Type>> config)
        {
            Consumers = new List<Type>();
            config(Consumers);
        }
        private List<Type> Consumers { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("MassTransitServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.AddMassTransit(cfg =>
            {
                if (Consumers.Any())
                {
                    Consumers.ForEach(consumer => cfg.AddConsumer(consumer));
                }

                cfg.AddBus(BusFactory);
            });
        }

        private IBusControl BusFactory(IComponentContext context)
        {
            return Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.ConfigureEndpoints(context);
            });
        }
    }

}

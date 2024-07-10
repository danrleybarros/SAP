namespace Gcsb.Connect.SAP.Infrastructure.ApiClients
{
    using Autofac;

    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in InMemoryDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("ApiClients"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

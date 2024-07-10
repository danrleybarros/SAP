namespace Gcsb.Connect.SAP.Infrastructure.Modules
{
    using Autofac;
    using System;

    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Gcsb.Connect.SAP.WebApi
            //

            Type configStartup = Type.GetType("Gcsb.Connect.SAP.WebApi.Config.Startup, Gcsb.Connect.SAP.WebApi.Config");
            if (configStartup != null)
                builder.RegisterAssemblyTypes(configStartup.Assembly)
                    .AsSelf()
                    .InstancePerLifetimeScope();

            Type filesStartup = Type.GetType("Gcsb.Connect.SAP.WebApi.Files.Startup, Gcsb.Connect.SAP.WebApi.Files");
            if (filesStartup != null)
                builder.RegisterAssemblyTypes(filesStartup.Assembly)
                    .AsSelf()
                    .InstancePerLifetimeScope();
        }
    }
}

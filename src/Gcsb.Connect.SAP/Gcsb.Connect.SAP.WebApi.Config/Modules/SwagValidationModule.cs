using Autofac;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.Modules
{
    public class SwagValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

        }
    }
}

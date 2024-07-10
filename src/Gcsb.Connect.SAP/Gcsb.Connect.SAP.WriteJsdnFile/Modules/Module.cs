using Autofac;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.ExecuteJob;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.FAT57;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.Lei1601;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Modules
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<ExecuteJobUsecase>().As<IExecuteJobUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<TriggerFAT57UseCase>().As<ITriggerFAT57UseCase>().InstancePerLifetimeScope();
            builder.RegisterType<TriggerLei1601UseCase>().As<ITriggerLei1601UseCase>().InstancePerLifetimeScope();
        }
    }
}

using System.Linq;
using Autofac;

namespace Template.Application.ApplicationModule
{
    public class ApplicationDiModule : ModularInjection.DiModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var assembly = this.GetType().Assembly;
            ContainerBuilder.RegisterAssemblyTypes(assembly)
                .PublicOnly()
                .Where(t => t.Name.EndsWith("UserCase"))
                .InstancePerLifetimeScope();
        }

        public override void PostInitialize()
        {
        }
    }
}

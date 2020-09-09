using ModularInjection.Attributes;
using Template.Adapter.AdapterModule;
using Template.Application.ApplicationModule;

namespace Template.Mvc.DiModule
{
    [DependsOn(typeof(ApplicationDiModule), typeof(AdapterDiModule))]
    public class StartupDiModule : ModularInjection.DiModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
        }

        public override void PostInitialize()
        {
        }
    }
}

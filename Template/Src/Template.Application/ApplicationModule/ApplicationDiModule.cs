using Core.Modularity;
using Core.Modularity.Attribute;
using Microsoft.Extensions.DependencyInjection;
using Template.Adapter.AdapterModule;

namespace Template.Application.ApplicationModule
{
    [DependsOn(typeof(AdapterDiModule))]
    public class ApplicationDiModule : CoreModuleBase
    {
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddScoped<OrderService>();
            context.Services.AddScoped<ProductService>();
            context.Services.AddScoped<PaymentService>();
        }
    }
}

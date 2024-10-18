using Core.EntityFrameworkCore;
using Core.Modularity;
using Core.Modularity.Attribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Repositories;
using Template.EntityFramework.Repositories;

namespace Template.EntityFramework.EfCoreModule
{
    [DependsOn(typeof(CoreEfCoreModule))]
    public class EfCoreDiModule : CoreModuleBase
    {
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddScoped<IOrderRepository, OrderRepository>();
            context.Services.AddScoped<IProductRepository, ProductRepository>();
            context.Services.AddScoped<IPaymentRepository, PaymentRepository>();

            context.Services
                .AddDbContextAndEfRepositories<TemplateDbContext>(options =>
                {
                    options.UseInMemoryDatabase("template");
                });
        }
    }
}

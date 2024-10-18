using Core.EventBus;
using Core.Modularity;
using Core.Modularity.Attribute;
using Core.Uow;
using Microsoft.OpenApi.Models;
using Template.Application.ApplicationModule;
using Template.EntityFramework.EfCoreModule;

namespace Template.Api.DiModule
{
    [DependsOn(typeof(ApplicationDiModule),
        typeof(EfCoreDiModule))]
    public class StartupDiModule : CoreModuleBase
    {

        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddControllers();

            context.Services.Configure<EventBusOptions>(options =>
            {
                options.AddConsumers(typeof(StartupDiModule).Assembly);
            });

            // 配置 Swagger
            context.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDDExample API", Version = "v1" });
            });

        }

        public override void Configure(ApplicationBuilderContext context)
        {
            var app = context.ApplicationBuilder;
            var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启用 Swagger 中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDDExample API V1");
            });

            app.UseRouting();

            app.UseUnitOfWork();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using BoletoService.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BoletoService.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddBoletoContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                 .AddDbContext<BoletoContext>(options =>
                 {
                     options.UseLoggerFactory(LoggerFactory.Create(build => build.AddConsole()));
                     options.UseNpgsql(configuration.GetConnectionString("BasePostgreSQLBoleto"));
                     options.EnableDetailedErrors().EnableSensitiveDataLogging();
                 }
                 );

            return services;
        }
        public static WebApplication ConfigurationPostgresEscopo(this WebApplication application)
        {
            using IServiceScope serviceScope = application.Services.CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<BoletoContext>().Database.Migrate();
            return application;
        }
    }
}

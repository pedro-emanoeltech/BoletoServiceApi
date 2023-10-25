using BoletoService.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BoletoService.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddBoletoContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                 .AddDbContext<BoletoContext>(
                     options => options.UseNpgsql(
                         configuration.GetConnectionString("BasePostgreSQLBoleto")));

            return services;
        }
    }
}

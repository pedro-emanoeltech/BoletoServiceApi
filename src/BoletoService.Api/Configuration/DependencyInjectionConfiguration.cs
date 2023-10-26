using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Interfaces;
using BoletoService.Application.Services;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using BoletoService.Domain.Services;
using BoletoService.Infra;
using BoletoService.Infra.Services;
using FluentValidation;
using static BoletoService.Application.Dtos.Request.BancoRequest;
using static BoletoService.Application.Dtos.Request.BoletoRequest;

namespace BoletoService.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IBancoServiceApp, BancoServiceApp>();

            services.AddScoped<IBoletoRepository, BoletoRepository>();
            services.AddScoped<IInfoBoletoService, InfoBoletoService>();
            services.AddScoped<IBoletoServiceApp, BoletoServiceApp>();


            services.AddTransient<IValidator<BancoRequest>, BancoRequestValidator>();
            services.AddTransient<IValidator<BoletoRequest>, BoletoRequestValidator>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

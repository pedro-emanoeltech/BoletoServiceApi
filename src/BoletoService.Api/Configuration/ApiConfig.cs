using BoletoService.Application.AutoMapper;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BoletoService.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BoletoApi (teste técnico)",
                    Description = "ASP.NET Core C# REST API, DDD, Princípios SOLID e Clean Architecture",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro Emanoel",
                        Email = "pedro.emanoeltech@hotmail.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });

            services.AddHttpLogging(delegate (HttpLoggingOptions options)
            {
                options.LoggingFields = HttpLoggingFields.ResponseStatusCode;
            });

            services.Configure(delegate (RouteOptions routeOptions)
            {
                routeOptions.LowercaseUrls = true;
                routeOptions.LowercaseQueryStrings = true;
            });

            services.AddHttpContextAccessor();

            services.AddControllers().ConfigureApiBehaviorOptions(delegate (ApiBehaviorOptions options)
            {
                options.SuppressMapClientErrors = true;
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IServiceCollection AutoMapperConfiguration(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(DomainToResponseMapper));
            services.AddAutoMapper(typeof(RequestToDomainMapper));
            return services;
        }
        public static void UseConfigureApi(this IApplicationBuilder app)
        {
            app.UseHttpLogging();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoletoApi v1");
            });

        }
    }
}

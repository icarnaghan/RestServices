using RestServices.Data.Repositories;
using RestServices.Domain.Repositories;
using RestServices.Domain.Supervisor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RestServices.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }

        public static IServiceCollection ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IRestServicesSupervisor, RestServicesSupervisor>();

            return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>        
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            }
        );
        
        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );

            return services;
        }
    }
}
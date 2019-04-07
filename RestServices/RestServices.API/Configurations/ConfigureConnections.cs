using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestServices.Domain.DbInfo;
using RestServices.Data;

namespace RestServices.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connection = String.Empty;
            
            connection = configuration.GetConnectionString("RestServicesDbDocker") ??
                                 "Server=localhost,1433;Database=RestServices;User=sa;Password=ChangeMe1!!;Trusted_Connection=False;Application Name=RestServices";
            
            services.AddDbContextPool<RestServicesContext>(options => options.UseSqlServer(connection));

            services.AddSingleton(new DbInfo(connection));

            return services;
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTik_Db.Configuration;

namespace UniversityTik.DPI
{
    public static class ConfigureOptionsExtensions
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));
            return services;
        }
    }
}

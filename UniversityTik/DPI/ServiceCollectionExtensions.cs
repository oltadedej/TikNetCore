using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTik_Db.Service;
using UniversityTik_Db.Service.Contract;

namespace UniversityTik.DPI
{
    public static class ServiceCollectionExtensions
    {
        //Konfigurimi i serviceve per aplikacionin
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUniversityService, UniversityService>();
            //  services.AddScoped<ICourseService, CourseService>();
            services.AddSingleton<StaticCache>();

            return services;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RrepTest.Filters;

namespace RrepTest.MyAttributes
{
    public static class FilterServices
    {
        public static void AddFiltersService(this IServiceCollection services)
        {
            Assembly filterAssembly = Assembly.GetExecutingAssembly();
            var types = filterAssembly.GetTypes().Where(x => x.GetCustomAttributes<UniversalFilterAttribut>().Any());
                services.AddMvc(option =>
                {
                    foreach (var type in types)
                    {
                        option.Filters.Add(type);
                    }
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}

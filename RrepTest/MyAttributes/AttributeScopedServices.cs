using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using RrepTest.Interfaces.IRepository;
using RrepTest.Repository;

namespace RrepTest.MyAttributes
{
    public static class AttributeScopedServices
    {
        
        public static void  AddSServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(x => x.GetCustomAttributes<UniversalDIAttribute>().Any());

            foreach (var type in types)
            {
                var getEnumVal = type.GetCustomAttribute<UniversalDIAttribute>().Name;
                Type t = type;
                Type[] getAllInterfaces = type.GetInterfaces();
                foreach (var it in getAllInterfaces)
                {
                    if (it.IsGenericType && type.IsGenericType)
                    {
                        if (it.IsGenericTypeDefinition && type.IsGenericTypeDefinition)
                        {
                            switch (getEnumVal)
                            {
                                case EnumServiceForDI.Scoped:
                                    services.AddScoped(it, t);
                                    break;
                                case EnumServiceForDI.Transient:
                                    services.AddTransient(it, t);
                                    break;
                                case EnumServiceForDI.Singleton:
                                    services.AddSingleton(it, t);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (getEnumVal)
                        {
                            case EnumServiceForDI.Scoped:
                                services.AddScoped(it, t);
                                break;
                            case EnumServiceForDI.Transient:
                                services.AddTransient(it, t);
                                break;
                            case EnumServiceForDI.Singleton:
                                services.AddSingleton(it, t);
                                break;
                        }
                    }
                }
            }

        }

    }

}

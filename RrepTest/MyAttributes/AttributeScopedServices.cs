using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;


namespace RrepTest.MyAttributes
{
    public static class AttributeScopedServices
    {
        
        public static void  AddSServices(this IServiceCollection services)
        {
            //List<string> scopedClass = new List<string>();
            //var assembly = Assembly.GetExecutingAssembly();
            //var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<AddScopedAttribute>().Count() > 0 ||
            //                                           t.GetCustomAttributes<AddTransientAttribute>().Count() > 0 ||
            //                                           t.GetCustomAttributes<AddSingletonAttribute>().Count() > 0);

            //foreach (var type in types)
            //{
            //    var getIniterface = type.GetInterfaces();
            //    var mainIntefaces = getIniterface.Except(getIniterface.SelectMany(t => t.GetInterfaces()));
            //    foreach (var itype in mainIntefaces)
            //    {
            //        services.AddScoped(itype, type);
            //    }

            //}

            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(x => x.GetCustomAttributes<UniversalDIAttribute>().Any());

            foreach (var type in types)
            {
                if (type.IsAbstract)
                {
                    continue;
                }

                var getEnumVal = type.GetCustomAttribute<UniversalDIAttribute>().Name;
                var getInterface = type.GetInterfaces().FirstOrDefault(x => !x.IsGenericType);
                Type t = type;
                //-------------------------
                Type[] getAllInterfaces = type.GetInterfaces();
                var someTypes = type.GetInterfaces();
                foreach (var p in someTypes)
                {
                    if (p.IsGenericType && type.IsGenericType)
                    {

                        //services.AddSingleton(typeof())
                    }
                    //scopedClass.Add(p.Name + " IsGeneric: (" + p.IsGenericType + ") |==> " + type.Name + " IsGeneric: (" + type.IsGenericType + ")");
                    //scopedClass.Add("------------------------------------------------------------------------");
                }
                //--------------------------
                switch (getEnumVal)
                {
                    case EnumServiceForDI.Scoped:
                        services.AddScoped(getInterface, t);
                        break;
                    case EnumServiceForDI.Transient:
                        services.AddTransient(getInterface, t);
                        break;
                    case EnumServiceForDI.Singleton:
                        services.AddSingleton(getInterface, t);
                        break;
                }

            }

        }

    }

}

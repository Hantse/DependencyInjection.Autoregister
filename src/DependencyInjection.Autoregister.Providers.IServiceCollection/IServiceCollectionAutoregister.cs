using DependencyInjection.Autoregister.Abstraction.Attributes;
using DependencyInjection.Autoregister.Abstraction.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjection.Autoregister.Providers.ServiceCollection
{
    public static class AddAutoRegistration
    {
        public static IServiceCollection AddAutoRegister(this IServiceCollection services)
        {
            GetTypesWithHelpAttribute(services, Assembly.GetEntryAssembly());
            return services;
        }

        public static IServiceCollection AddAutoRegister(this IServiceCollection services, Assembly assembly)
        {
            GetTypesWithHelpAttribute(services, assembly);
            return services;
        }

        private static void GetTypesWithHelpAttribute(IServiceCollection services, Assembly assembly)
        {
            foreach (AssemblyName asem in assembly.GetReferencedAssemblies()
                .Where(a => !a.FullName.StartsWith("System")
                            && !a.FullName.StartsWith("Microsoft")))
            {
                Assembly loadAssembly = Assembly.Load(asem);

                foreach (Type type in loadAssembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(DependencyRegistration), true).Length > 0)
                    {
                        AddToStack(services, type);
                    }
                }

                GetTypesWithHelpAttribute(services, loadAssembly);
            }

            //foreach (Type type in assembly.GetTypes())
            //{
            //    if (type.GetCustomAttributes(typeof(DependencyRegistration), true).Length > 0)
            //    {
            //        AddToStack(services, type);
            //    }
            //}
        }

        private static void AddToStack(IServiceCollection services, Type type)
        {
            ServiceRegistrationType registrationType = GetRegistrationType(type);
            Type interfaceOf = GetRegistrationInterfaceType(type);
            Type[] interfaces = type.GetInterfaces();

            if (interfaceOf == null && interfaces.Length > 0)
            {
                for (int i = 0; i < interfaces.Length; i++)
                {
                    RegisterFromInterface(services, registrationType, type, interfaces[i]);
                }
            }
            else
            {
                RegisterFromInterface(services, registrationType, type, interfaceOf);
            }
        }

        private static void RegisterFromInterface(IServiceCollection services, ServiceRegistrationType registrationType, Type type, Type interfaceOf)
        {
            if (registrationType == ServiceRegistrationType.SCOPED)
            {
                if (interfaceOf != null)
                    services.AddScoped(interfaceOf, type);
                else
                    services.AddScoped(type);
            }
            else if (registrationType == ServiceRegistrationType.TRANSCIENT)
            {
                if (interfaceOf != null)
                    services.AddTransient(interfaceOf, type);
                else
                    services.AddTransient(type);
            }
            else
            {
                if (interfaceOf != null)
                    services.AddSingleton(interfaceOf, type);
                else
                    services.AddSingleton(type);
            }
        }

        private static ServiceRegistrationType GetRegistrationType(Type type)
        {
            return GetAttribute(type).RegistrationType;
        }

        private static Type GetRegistrationInterfaceType(Type type)
        {
            return GetAttribute(type).InterfaceOf;
        }

        private static DependencyRegistration GetAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(DependencyRegistration), true).First() as DependencyRegistration;
        }
    }
}

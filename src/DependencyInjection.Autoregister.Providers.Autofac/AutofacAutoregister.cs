using Autofac;
using DependencyInjection.Autoregister.Abstraction.Attributes;
using DependencyInjection.Autoregister.Abstraction.Helpers;
using DependencyInjection.Autoregister.Abstraction.Models;
using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjection.Autoregister.Providers
{
    public static class AutofacAutoregister
    {
        public static ContainerBuilder AutoRegister(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                       .Where(t => t.GetCustomAttributes(typeof(DependencyRegistration), true).Length > 0);


            return builder;
        }

        private static void RegisterFromAssemlyLoad(ContainerBuilder builder, Assembly assembly)
        {
            var registrations = AssemblyIterator.LoadFromAssembly(assembly);

            foreach (var reg in registrations)
            {
                Register(builder, reg.Type, reg.ServiceType, reg.ImplementationType);
            }
        }

        private static void Register(ContainerBuilder builder, ServiceRegistrationType registrationType, Type serviceType, Type implementationType)
        {
            if (registrationType == ServiceRegistrationType.SCOPED)
            {
                if (serviceType != null)
                    builder.RegisterType(implementationType)
                            .As(serviceType)
                            .InstancePerLifetimeScope();
                else
                    builder.RegisterType(implementationType)
                            .InstancePerLifetimeScope();
            }
            else if (registrationType == ServiceRegistrationType.TRANSIENT)
            {
                if (serviceType != null)
                    builder.RegisterType(implementationType)
                            .As(serviceType);
                else
                    builder.RegisterType(implementationType);
            }
            else
            {
                if (serviceType != null)
                    builder.RegisterType(implementationType)
                            .As(serviceType)
                            .SingleInstance();
                else
                    builder.RegisterType(implementationType)
                           .SingleInstance();
            }
        }
    }
}

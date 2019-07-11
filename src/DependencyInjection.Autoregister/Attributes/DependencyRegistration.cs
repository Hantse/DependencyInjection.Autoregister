using DependencyInjection.Autoregister.Abstraction.Models;
using System;

namespace DependencyInjection.Autoregister.Abstraction.Attributes
{
    interface IDependencyRegistration
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DependencyRegistration : System.Attribute, IDependencyRegistration
    {
        public ServiceRegistrationType RegistrationType { get; set; }
        public Type InterfaceOf { get; set; }
        public string Name { get; set; }

        public DependencyRegistration(ServiceRegistrationType registrationType = ServiceRegistrationType.SCOPED)
        {
            RegistrationType = registrationType;
        }

        public DependencyRegistration(string name, ServiceRegistrationType registrationType = ServiceRegistrationType.SCOPED)
            : this(registrationType)
        {
            Name = name;
        }

        public DependencyRegistration(ServiceRegistrationType registrationType, Type interfaceOf)
            : this(registrationType)
        {
            InterfaceOf = interfaceOf;
        }

        public DependencyRegistration(string name, Type interfaceOf, ServiceRegistrationType registrationType = ServiceRegistrationType.SCOPED)
            : this(name, registrationType)
        {
            InterfaceOf = interfaceOf;
        }
    }
}

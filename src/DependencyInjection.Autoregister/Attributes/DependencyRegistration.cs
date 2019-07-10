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

        public DependencyRegistration(ServiceRegistrationType registrationType = ServiceRegistrationType.SCOPED)
        {
            RegistrationType = registrationType;
        }

        public DependencyRegistration(ServiceRegistrationType registrationType, Type interfaceOf) : this(registrationType)
        {
            InterfaceOf = interfaceOf;
        }
    }

}

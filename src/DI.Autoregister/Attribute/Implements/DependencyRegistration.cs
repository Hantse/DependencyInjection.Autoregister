using DI.Autoregister.Attribute.Interfaces;
using System;

namespace DI.Autoregister
{
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

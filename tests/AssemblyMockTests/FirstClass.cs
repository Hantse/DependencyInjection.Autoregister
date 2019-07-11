using AssemblySubMockTests;
using DependencyInjection.Autoregister.Abstraction.Attributes;
using System;

namespace AssemblyMockTests
{
    [DependencyRegistration(DependencyInjection.Autoregister.Abstraction.Models.ServiceRegistrationType.SCOPED)]
    public class FirstClass
    {
        public FirstClass()
        {
            SubLoadClass sub = new SubLoadClass();
        }
    }
}

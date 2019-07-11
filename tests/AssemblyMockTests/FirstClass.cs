using DependencyInjection.Autoregister.Abstraction.Attributes;
using System;

namespace AssemblyMockTests
{
    [DependencyRegistration(DependencyInjection.Autoregister.Abstraction.Models.ServiceRegistrationType.SCOPED)]
    public class FirstClass
    {
    }
}

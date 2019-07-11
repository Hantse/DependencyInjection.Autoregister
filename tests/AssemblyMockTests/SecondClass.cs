using DependencyInjection.Autoregister.Abstraction.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyMockTests
{
    public interface ISecondClass
    {
    }

    [DependencyRegistration(DependencyInjection.Autoregister.Abstraction.Models.ServiceRegistrationType.SCOPED)]
    public class SecondClass : ISecondClass
    {
    }
}

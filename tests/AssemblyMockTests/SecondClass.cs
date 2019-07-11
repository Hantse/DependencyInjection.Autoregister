using DependencyInjection.Autoregister.Abstraction.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyMockTests
{
    public interface ISecondClass
    {
    }

    [DependencyRegistration("MyName")]
    public class SecondClass : ISecondClass
    {
    }
}

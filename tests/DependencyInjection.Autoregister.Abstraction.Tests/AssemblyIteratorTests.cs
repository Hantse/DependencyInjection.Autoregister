using DependencyInjection.Autoregister.Abstraction.Helpers;
using DependencyInjection.Autoregister.Abstraction.Models;
using System.Reflection;
using Xunit;
using AssemblyMockTests;

namespace DependencyInjection.Autoregister.Abstraction.Tests
{
    public class AssemblyIteratorTests
    {
        public AssemblyIteratorTests()
        {
            FirstClass firstClass = new FirstClass();
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly()
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly());

            ServiceRegistration[] servicesFounds = AssemblyIterator.LoadFromAssembly(Assembly.GetEntryAssembly());
        }
    }
}

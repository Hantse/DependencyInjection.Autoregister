using DependencyInjection.Autoregister.Abstraction.Helpers;
using DependencyInjection.Autoregister.Abstraction.Models;
using System.Reflection;
using Xunit;
using AssemblyMockTests;
using System.Linq;

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
            Assert.Equal(2, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ServiceType.Equals(typeof(AssemblyMockTests.FirstClass)));
        }
    }
}
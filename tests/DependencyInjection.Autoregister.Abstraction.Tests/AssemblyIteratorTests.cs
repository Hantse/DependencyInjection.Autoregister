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
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByImplementation()
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly());
            Assert.Equal(3, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ImplementationType.Equals(typeof(AssemblyMockTests.FirstClass)));
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByServiceType()
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly());
            Assert.Equal(3, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ServiceType != null && a.ServiceType.Equals(typeof(AssemblyMockTests.ISecondClass)));
        }

        [Theory]
        [InlineData("AssemblyMockTests", 3)]
        public void ShouldLoadSomeServicesFromExecutingAssembly_WithSpecificNamespaceStart_CheckRegistrationByImplementation(string startWith, int exceptedResult)
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly(), startWith);
            Assert.Equal(exceptedResult, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ImplementationType.Equals(typeof(AssemblyMockTests.FirstClass)));
        }

        [Theory]
        [InlineData("AssemblyMockTests", 3)]
        public void ShouldLoadSomeServicesFromExecutingAssembly_WithSpecificNamespaceStart_CheckRegistrationByServiceType(string startWith, int exceptedResult)
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly(), startWith);
            Assert.Equal(exceptedResult, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ImplementationType.Equals(typeof(AssemblyMockTests.FirstClass)));
            Assert.Contains(servicesFound, a => a.ServiceType != null && a.ServiceType.Equals(typeof(AssemblyMockTests.ISecondClass)));
        }

        [Theory]
        [InlineData("AssemblyMockTests", 3)]
        public void ShouldLoadSomeServicesFromExecutingAssembly_WithSpecificNamespacesStart_CheckRegistrationByImplementation(string startsWith, int exceptedResult)
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly(), startsWith.Split(";"));
            Assert.Equal(exceptedResult, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ImplementationType.Equals(typeof(AssemblyMockTests.FirstClass)));
        }

        [Theory]
        [InlineData("AssemblyMockTests", 3)]
        public void ShouldLoadSomeServicesFromExecutingAssembly_WithSpecificNamespacesStart_CheckRegistrationByServiceType(string startsWith, int exceptedResult)
        {
            ServiceRegistration[] servicesFound = AssemblyIterator.LoadFromAssembly(Assembly.GetExecutingAssembly(), startsWith.Split(";"));
            Assert.Equal(exceptedResult, servicesFound.Length);
            Assert.Contains(servicesFound, a => a.ServiceType != null && a.ServiceType.Equals(typeof(AssemblyMockTests.ISecondClass)));
        }
    }
}

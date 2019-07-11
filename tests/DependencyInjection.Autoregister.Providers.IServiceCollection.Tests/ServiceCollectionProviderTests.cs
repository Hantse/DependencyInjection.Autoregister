using AssemblyMockTests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Xunit;

namespace DependencyInjection.Autoregister.Providers.IServiceCollection.Tests
{
    public class ServiceCollectionProviderTests
    {
        public ServiceCollectionProviderTests()
        {
            FirstClass firstClass = new FirstClass();
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByImplementation_LoadByAssembly()
        {
            var services = new ServiceCollection();
            services.AddAutoRegister(Assembly.GetAssembly(typeof(ServiceCollectionProviderTests)));
            var provider = services.BuildServiceProvider();
            var resolveService = provider.GetService<FirstClass>();

            Assert.NotNull(resolveService);
            Assert.IsType<FirstClass>(resolveService);
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByServiceType_LoadByAssembly()
        {
            var services = new ServiceCollection();
            services.AddAutoRegister(Assembly.GetAssembly(typeof(ServiceCollectionProviderTests)));
            var provider = services.BuildServiceProvider();
            var resolveService = provider.GetService<ISecondClass>();

            Assert.NotNull(resolveService);
            Assert.IsAssignableFrom<ISecondClass>(resolveService);
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByImplementation_LoadByType()
        {
            var services = new ServiceCollection();
            services.AddAutoRegister(typeof(ServiceCollectionProviderTests));
            var provider = services.BuildServiceProvider();
            var resolveService = provider.GetService<FirstClass>();

            Assert.NotNull(resolveService);
            Assert.IsType<FirstClass>(resolveService);
        }

        [Fact]
        public void ShouldLoadSomeServicesFromExecutingAssembly_CheckRegistrationByServiceType_LoadByType()
        {
            var services = new ServiceCollection();
            services.AddAutoRegister(typeof(ServiceCollectionProviderTests));
            var provider = services.BuildServiceProvider();
            var resolveService = provider.GetService<ISecondClass>();

            Assert.NotNull(resolveService);
            Assert.IsAssignableFrom<ISecondClass>(resolveService);
        }
    }
}

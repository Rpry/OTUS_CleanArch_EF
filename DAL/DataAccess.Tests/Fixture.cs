using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StateMachine.Compose;
using Xunit.Abstractions;

namespace Tests
{
    public class Fixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        public IServiceProvider GetServiceProvider(ITestOutputHelper testOutputHelper = null)
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.Build();
            var serviceCollection = ServiceCollectionExtensions.PopulateServiceCollection(new ServiceCollection(), configuration, "Tests");
            serviceCollection.ConfigureInMemoryContext();
            var serviceProvider =  serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        /// <summary>
        /// Выполняется перед запуском тестов
        /// </summary>
        public Fixture()
        {
            var serviceProvider = GetServiceProvider();
            ServiceProvider = serviceProvider;
            Environment.SetEnvironmentVariable("SkipDeepLogging", "true");
        }

        public void Dispose()
        {
        }
    }
}

using System;
using DesignPatterns.Strategy.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Strategy
{
    public static class Resolver
    {
        public static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IPayTollServices, PayTollServices>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
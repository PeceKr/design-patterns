using System;
using DesignPatterns.Observer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Observer
{
    public static class Resolver
    {
        public static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IOrderServices, OrderServices>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
using System;
using DesignPatterns.Repository.Infrastructure;
using DesignPatterns.Repository.Repositories;
using DesignPatterns.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Repository
{
    public static class Resolver
    {
        public static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<PostsDbContext>(opt => opt.UseInMemoryDatabase("posts"));
            serviceCollection.AddSingleton<IUsersRepository, UsersRepository>();
            serviceCollection.AddSingleton<IPostsRepository, PostRepository>();
            serviceCollection.AddSingleton<IPostServices, PostServices>();
            serviceCollection.AddSingleton<IUserServices, UserServices>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatterns.Repository.Models;
using DesignPatterns.Repository.Services;

namespace DesignPatterns.Repository
{
    class Program
    {
        public static IServiceProvider _serviceProvider { get; set; }

        static void Main(string[] args)
        {
            // Inject Services
            _serviceProvider = Resolver.ConfigureService();
            var _userService = (IUserServices)_serviceProvider.GetService(typeof(IUserServices));
            var _postService = (IPostServices)_serviceProvider.GetService(typeof(IPostServices));

            // Add new users
            var firstUser = new User { FirstName = "First", LastName = "User" };
            var secondUser = new User { FirstName = "Second", LastName = "User" };
            AddNewUser(firstUser, _userService).Wait();
            AddNewUser(secondUser, _userService).Wait();

            var users = GetAllusers(_userService).Result;
            foreach (var item in users)
            {
                System.Console.WriteLine(item.FirstName);
            }

            // Add new posts
            AddNewPost(new Post { UserId = firstUser.Id, Content = "Repository Pattern" }, _postService).Wait();
            AddNewPost(new Post { UserId = secondUser.Id, Content = "Repository Pattern for second user" }, _postService).Wait();
            var posts = GetAllPosts(_postService).Result;
            foreach (var item in posts)
            {
                System.Console.WriteLine(item.Content);
            }

            // Get User example
            var user = GetUser(secondUser.Id, _userService).Result;

            // Get all posts by user
            var userPost = GetUserPosts(user.Id, _postService).Result;
        }

        private static async Task AddNewUser(User user, IUserServices userServices)
        {

            await userServices.AddNewUser(user);
        }

        private static async Task<User> GetUser(int userId, IUserServices userServices)
        {

            return await userServices.GetUser(userId);
        }

        private static async Task<IEnumerable<User>> GetAllusers(IUserServices userServices)
        {
            return await userServices.GetAll();
        }

        private static async Task AddNewPost(Post post, IPostServices userServices)
        {

            await userServices.AddNewPost(post);
        }

        private static async Task<IEnumerable<Post>> GetAllPosts(IPostServices postServices)
        {
            return await postServices.GetAll();
        }
        private static async Task<IEnumerable<Post>> GetUserPosts(int userId, IPostServices postServices)
        {
            return await postServices.GetPostsByUser(userId);
        }
    }
}

using System.Threading.Tasks;
using DesignPatterns.Repository.Infrastructure;
using DesignPatterns.Repository.Models;
using DesignPatterns.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DesignPatterns.Repository.Tests
{
    public class PostsRepositoryTests
    {
        private IUsersRepository _userRepository;
        private IPostsRepository _postsRepository;
        private DbContextOptions<PostsDbContext> dbContextOptions = new DbContextOptionsBuilder<PostsDbContext>()
        .UseInMemoryDatabase(databaseName: "posts")
        .Options;
        private PostsDbContext _dbContext;

        [SetUp]
        public async Task Setup()
        {
            _dbContext = new PostsDbContext(dbContextOptions);
            _userRepository = new UsersRepository(_dbContext);
            _postsRepository = new PostRepository(_dbContext);
          

            var user = new User { FirstName = "First", LastName = "User" };
            _userRepository.Add(user);
            await _userRepository.SaveChanges();

            var post = new Post { UserId = user.Id, Content = "Test content" };
            _postsRepository.Add(post);
            await _postsRepository.SaveChanges();
        }

        [Test]
        public async Task Should_Get_One_Post()
        {
            var post = await _postsRepository.GetByIdAsync(1);

            Assert.IsNotNull(post);
        }

        [Test]
          public async Task Should_Get_User_Posts()
        {
            int userId = 1;

            var posts = await _postsRepository.GetAsync(x => x.UserId == userId);

            Assert.IsNotEmpty(posts);
        }

        
    }
}
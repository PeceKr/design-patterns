using System.Threading.Tasks;
using DesignPatterns.Repository.Infrastructure;
using DesignPatterns.Repository.Models;
using DesignPatterns.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DesignPatterns.Repository.Tests
{
    public class UserRepositoryTests
    {
        private IUsersRepository _userRepository;        
        private DbContextOptions<PostsDbContext> dbContextOptions = new DbContextOptionsBuilder<PostsDbContext>()
        .UseInMemoryDatabase(databaseName: "posts")
        .Options;
        private PostsDbContext _dbContext;

        [SetUp]
        public async Task Setup()
        {
            _dbContext = new PostsDbContext(dbContextOptions);
            _userRepository = new UsersRepository(_dbContext);            
          

            var user = new User { FirstName = "First", LastName = "User" };
            _userRepository.Add(user);
            await _userRepository.SaveChanges();           
        }

        [Test]
        public async Task Should_Get_One_User()
        {
            var user = await _userRepository.GetByIdAsync(1);

            Assert.IsNotNull(user);
        }

        [Test]
        public async Task Should_Add_One_User () {
            var user = new User { FirstName = "FirstNameUser", LastName = "LastNameUser" };

            _userRepository.Add(user);
            await _userRepository.SaveChanges();

            Assert.IsTrue(user.Id != 0);
        }

        [Test]
        public async Task Should_Get_All_Users_With_Given_Name ()
        {
            var nameForQuery = "First";

            var users = await _userRepository.GetAsync(x => x.FirstName == nameForQuery);

            Assert.IsNotEmpty(users);
        }
    }
}
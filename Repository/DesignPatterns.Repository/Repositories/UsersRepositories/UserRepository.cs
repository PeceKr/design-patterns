using DesignPatterns.Repository.Infrastructure;
using DesignPatterns.Repository.Models;

namespace DesignPatterns.Repository.Repositories
{
    public class UsersRepository :GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(PostsDbContext context) : base(context)
        {
        }
    }
}

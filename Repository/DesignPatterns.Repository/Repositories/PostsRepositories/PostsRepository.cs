using DesignPatterns.Repository.Infrastructure;
using DesignPatterns.Repository.Models;

namespace DesignPatterns.Repository.Repositories
{
    public class PostRepository :GenericRepository<Post>, IPostsRepository
    {
        public PostRepository(PostsDbContext context) : base(context)
        {
        }
    }
}

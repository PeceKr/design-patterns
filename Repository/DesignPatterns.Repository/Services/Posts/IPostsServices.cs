using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatterns.Repository.Models;

namespace DesignPatterns.Repository.Services
{
    public interface IPostServices
    {
        Task AddNewPost(Post post);
        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<Post>> GetPostsByUser(int userId);
    }
}
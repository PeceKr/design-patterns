using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatterns.Repository.Models;
using DesignPatterns.Repository.Repositories;

namespace DesignPatterns.Repository.Services
{
    public class PostServices : IPostServices
    {
        private readonly IPostsRepository _postRepository;

        public PostServices(IPostsRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddNewPost(Post post)
        {
            try
            {
                _postRepository.Add(post);
                await _postRepository.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            try
            {
                return await _postRepository.GetAllAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            try
            {
                return await _postRepository.GetAsync(x => x.UserId == userId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
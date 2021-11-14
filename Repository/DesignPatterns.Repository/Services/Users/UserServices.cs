using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatterns.Repository.Models;
using DesignPatterns.Repository.Repositories;

namespace DesignPatterns.Repository.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUsersRepository _userRepository;

        public UserServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddNewUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                await _userRepository.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<User> GetUser(int userId)
        {
            try
            {
                return await _userRepository.GetByIdAsync(userId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
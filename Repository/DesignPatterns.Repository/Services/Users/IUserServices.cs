using System.Collections.Generic;
using System.Threading.Tasks;
using DesignPatterns.Repository.Models;

namespace DesignPatterns.Repository.Services
{
    public interface IUserServices
    {
        Task AddNewUser(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(int userId);
    }
}
using System.Threading.Tasks;
using FootiniApp.API.Models;

namespace FootiniApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
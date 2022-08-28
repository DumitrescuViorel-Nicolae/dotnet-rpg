using dotnet_rpg.Models;
using System.Threading.Tasks;

namespace dotnet_rpg.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<int> Register(User user, string password);
        Task<string> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}

using IPL.Entities;
using IPL.Models;

namespace IPL.Service.Contract
{
    public interface IUserService
    {
        Task AddUser(UserDTO user);
        Task<User?> GetUserByEmail(string email);
        Task<Tokens?> LoginUser(LoginUser user);
    }
}
using IPL.Entities;

namespace IPL.Data.Contract
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task<User?> GetUserByEmail(string email);
    }
}

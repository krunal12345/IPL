using IPL.Data.Contract;
using IPL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPL.Data.Repository
{
    public class UserRepository(IPLDbContext context): IUserRepository
    {
        public async Task AddUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(usr => usr.Email.ToLower() == email);
        }
    }
}

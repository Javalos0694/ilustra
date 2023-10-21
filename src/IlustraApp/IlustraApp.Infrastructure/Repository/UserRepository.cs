using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IlustraContext Context;
        public UserRepository(IlustraContext context)
        {
            Context = context;
        }

        public async Task CreateUser(User user)
        {
            await Context.AddAsync(user);
        }

        public async Task<List<User>> FindAll()
        {
            return await Context.User.Include(x => x.IdPersonNavigation).Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<List<User>> FindAllByFilters(int? userType, string username)
        {
            return await Context.User.Include(p => p.IdPersonNavigation).Where(x => (x.IdUserType == userType || x.Username.Contains(username)) && !x.Deleted).ToListAsync();
        }

        public async Task<User> FindUserByCode(string recoveryCode)
        {
            return await Context.User.FirstOrDefaultAsync(x => x.RecoveryPasswordCode == recoveryCode && !x.Deleted) ?? null;
        }

        public async Task<User> FindUserById(int id)
        {
            return await Context.User.Include(p => p.IdPersonNavigation).FirstOrDefaultAsync(x => x.IdUser == id && !x.Deleted) ?? null;
        }

        public async Task<User> FindUserByUsername(string username)
        {
            return await Context.User.Include(p => p.IdPersonNavigation).FirstOrDefaultAsync(x => x.Username == username && !x.Deleted) ?? null;
        }
    }
}

using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> FindAll();
        public Task<List<User>> FindAllByFilters(int? userType, string username);
        public Task<User> FindUserByUsername(string username);
        public Task<User> FindUserById(int id);
        public Task<User> FindUserByCode(string recoveryCode);
        public Task CreateUser(User user);
    }
}

using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;

namespace IlustraApp.Infrastructure.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IlustraContext Context;
        public BaseRepository(IlustraContext context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

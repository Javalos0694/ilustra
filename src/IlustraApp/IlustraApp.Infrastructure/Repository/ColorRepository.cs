using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly IlustraContext Context;
        public ColorRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task CreateColor(Color color)
        {
            await Context.Color.AddAsync(color);
        }

        public async Task<List<Color>> GetAllColors()
        {
            return await Context.Color.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Color> GetColorById(int id)
        {
            return await Context.Color.FirstOrDefaultAsync(x => x.IdColor == id && !x.Deleted);
        }
    }
}

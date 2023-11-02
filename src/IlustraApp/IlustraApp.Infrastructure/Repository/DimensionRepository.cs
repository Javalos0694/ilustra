using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class DimensionRepository : IDimensionRepository
    {
        private readonly IlustraContext Context;
        public DimensionRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task CreateDimension(Dimension dimension)
        {
            await Context.Dimension.AddAsync(dimension);
        }

        public async Task<List<Dimension>> GetAllDimension()
        {
            return await Context.Dimension.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Dimension> GetDimensionById(int dimensionId)
        {
            return await Context.Dimension.FirstOrDefaultAsync(x => x.IdDimension == dimensionId && !x.Deleted);
        }
    }
}

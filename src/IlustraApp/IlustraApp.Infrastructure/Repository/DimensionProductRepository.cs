using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class DimensionProductRepository : IDimensionProductRepository
    {
        private readonly IlustraContext Context;
        public DimensionProductRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task AssociateDimensionsByProduct(List<DimensionXproduct> dimensions)
        {
            await Context.DimensionXproduct.AddRangeAsync(dimensions);
        }

        public async Task<List<DimensionXproduct>> GetDimensionByProduct(int idProduct)
        {
            return await Context.DimensionXproduct.Include(x => x.IdDimensionNavigation).Where(x => x.IdProduct == idProduct).ToListAsync();
        }
    }
}

using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class ColorProductRepository : IColorProductRepository
    {
        private readonly IlustraContext Context;
        public ColorProductRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task AddColorsByProduct(List<ColorXproduct> colorXproducts)
        {
            await Context.ColorXproduct.AddRangeAsync(colorXproducts);
        }

        public async Task<List<ColorXproduct>> GetAllColorsByProduct(int idProduct)
        {
            return await Context.ColorXproduct.Include(x => x.IdColorNavigation).Where(x => x.IdProduct == idProduct).ToListAsync();
        }
    }
}

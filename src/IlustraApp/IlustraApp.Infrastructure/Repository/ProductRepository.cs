using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IlustraContext Context;
        public ProductRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task CreateProduct(Product product)
        {
            await Context.Product.AddAsync(product);
        }

        public async Task CreateProductCategory(ProductCategory productCategory)
        {
            await Context.ProductCategory.AddAsync(productCategory);
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await Context.Product.FirstOrDefaultAsync(x => x.IdProduct == productId && !x.Deleted);
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await Context.ProductCategory.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryById(int idProductCategory)
        {
            return await Context.ProductCategory.FirstOrDefaultAsync(x => x.IdProductCategory == idProductCategory && !x.Deleted);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await Context.Product.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await Context.Product.Where(x => x.IdProductCategory == categoryId && !x.Deleted).ToListAsync();
        }
    }
}

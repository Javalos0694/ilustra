using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<dynamic>> GetProducts();
        Task<List<Product>> GetProductsByCategory(int categoryId);
        Task CreateProductCategory(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategoryById(int idProductCategory);
        Task<List<ProductCategory>> GetProductCategories();
    }
}

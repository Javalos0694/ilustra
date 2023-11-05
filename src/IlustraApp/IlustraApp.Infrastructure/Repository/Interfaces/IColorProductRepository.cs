using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IColorProductRepository
    {
        Task AddColorsByProduct(List<ColorXproduct> colorXproducts);
        Task<List<ColorXproduct>> GetAllColorsByProduct(int idProduct);
    }
}

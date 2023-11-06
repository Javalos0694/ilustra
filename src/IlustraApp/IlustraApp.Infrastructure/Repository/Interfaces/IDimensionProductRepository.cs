using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IDimensionProductRepository
    {
        Task AssociateDimensionsByProduct(List<DimensionXproduct> dimensions);
        Task<List<DimensionXproduct>> GetDimensionByProduct(int idProduct);
    }
}

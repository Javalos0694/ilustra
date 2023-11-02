using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IDimensionRepository
    {
        Task<List<Dimension>> GetAllDimension();
        Task<Dimension> GetDimensionById(int dimensionId);
        Task CreateDimension(Dimension dimension);
    }
}

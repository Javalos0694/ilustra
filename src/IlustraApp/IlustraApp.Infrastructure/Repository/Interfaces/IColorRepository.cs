using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IColorRepository
    {
        Task CreateColor(Color color);
        Task<List<Color>> GetAllColors();
        Task<Color> GetColorById(int id);
    }
}

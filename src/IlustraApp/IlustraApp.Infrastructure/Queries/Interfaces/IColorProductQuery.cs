using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Queries.Interfaces
{
    public interface IColorProductQuery
    {
        Task DeleteColorsByProduct(int[] colors, int idProduct);
    }
}

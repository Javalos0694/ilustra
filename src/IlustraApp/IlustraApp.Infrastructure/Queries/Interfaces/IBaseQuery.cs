namespace IlustraApp.Infrastructure.Queries.Interfaces
{
    public interface IBaseQuery
    {
        Task DeleteAtributtesByProduct(int[] items, int idProduct, string itemType);
    }
}

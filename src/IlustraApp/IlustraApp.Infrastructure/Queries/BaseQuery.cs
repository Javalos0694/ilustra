using Dapper;
using IlustraApp.Infrastructure.Queries.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IlustraApp.Infrastructure.Queries
{
    public class BaseQuery : IBaseQuery
    {
        private readonly string ConnectionString;
        public BaseQuery(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "IlustraEntities");
        }

        public async Task DeleteAtributtesByProduct(int[] items, int idProduct, string itemType)
        {
            using SqlConnection connection = new(ConnectionString);

            await connection.QueryAsync("spDelete_ItemsByProduct", new
            {
                Items = string.Join(',', items),
                IdProduct = idProduct,
                ItemType = itemType
            },
            commandType: CommandType.StoredProcedure);
        }
    }
}

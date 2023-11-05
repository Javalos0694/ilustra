using Dapper;
using IlustraApp.Infrastructure.Queries.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IlustraApp.Infrastructure.Queries
{
    public class ColorProductQuery : IColorProductQuery
    {
        private readonly string ConnectionString;
        public ColorProductQuery(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "IlustraEntities");
        }

        public async Task DeleteColorsByProduct(int[] colors, int idProduct)
        {
            using SqlConnection connection = new(ConnectionString);

            await connection.QueryAsync("spDelete_ColorsByProduct", new
            {
                Colors = string.Join(',', colors),
                IdProduct = idProduct
            },
            commandType: CommandType.StoredProcedure);
        }
    }
}

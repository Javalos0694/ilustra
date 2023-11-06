using IlustraApp.Core.Bussiness.BDimension.Response;
using IlustraApp.Core.Bussiness.BDimensionProduct.Request;
using IlustraApp.Core.Bussiness.BDimensionProduct.Validate;
using IlustraApp.Infrastructure.Queries.Interfaces;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DimensionProductController : BaseController
    {
        private readonly IBaseQuery BaseQuery;
        private readonly IDimensionProductRepository DimensionProductRepository;
        private readonly IProductRepository ProductRepository;
        private readonly IBaseRepository BaseRepository;
        public DimensionProductController(IBaseQuery baseQuery, IDimensionProductRepository dimensionProductRepository, IProductRepository productRepository, IBaseRepository baseRepository)
        {
            BaseQuery = baseQuery;
            DimensionProductRepository = dimensionProductRepository;
            ProductRepository = productRepository;
            BaseRepository = baseRepository;
        }

        [HttpGet]
        [Route("{idProduct}")]
        public async Task<IActionResult> GetDimensionsByProduct(int idProduct)
        {
            var dimensions = await DimensionProductRepository.GetDimensionByProduct(idProduct);
            return Ok(new DimensionsResponse(dimensions));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AssociateDimensionsByProduct([FromBody] CreateDimensionProductRequest request)
        {
            var product = await ProductRepository.GetProductById(request.IdProduct);
            var dimensionsByProduct = await DimensionProductRepository.GetDimensionByProduct(product == null ? 0 : product.IdProduct);
            var validate = new CreateDimensionProductValidate(product, dimensionsByProduct, request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await BaseQuery.DeleteAtributtesByProduct(validate.DimensionsDeleted, product.IdProduct, "dimension");
            await DimensionProductRepository.AssociateDimensionsByProduct(validate.DimensionsProduct);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }
    }
}

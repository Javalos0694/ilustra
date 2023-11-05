using IlustraApp.Core.Bussiness.BColor.Response;
using IlustraApp.Core.Bussiness.BColorProduct.Request;
using IlustraApp.Core.Bussiness.BColorProduct.Validate;
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
    public class ColorProductController : BaseController
    {
        private readonly IColorProductRepository ColorProductRepository;
        private readonly IProductRepository ProductRepository;
        private readonly IColorProductQuery ColorProductQuery;
        private readonly IBaseRepository BaseRepository;
        public ColorProductController(IColorProductRepository colorProductRepository, IColorProductQuery colorProductQuery, IProductRepository productRepository, IBaseRepository baseRepository)
        {
            ColorProductRepository = colorProductRepository;
            ColorProductQuery = colorProductQuery;
            ProductRepository = productRepository;
            BaseRepository = baseRepository;
        }

        [HttpGet]
        [Route("{idProduct}")]
        public async Task<IActionResult> GetColorsByProduct(int idProduct)
        {
            var colors = await ColorProductRepository.GetAllColorsByProduct(idProduct);
            return Ok(new ColorsResponse(colors));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AssociateColorByProduct([FromBody] CreateColorProductRequest request)
        {
            var product = await ProductRepository.GetProductById(request.IdProduct);
            var colorsByProduct = await ColorProductRepository.GetAllColorsByProduct(product != null ? product.IdProduct : 0);
            var validate = new CreateColorProductValidate(request, product, colorsByProduct);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await ColorProductQuery.DeleteColorsByProduct(validate.ColorsDeleted, product.IdProduct);
            await ColorProductRepository.AddColorsByProduct(validate.ColorsByProduct);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteColorsByProduct([FromBody] DeleteColorProductRequest request)
        {
            var product = await ProductRepository.GetProductById(request.IdProduct);
            var colorsByProduct = await ColorProductRepository.GetAllColorsByProduct(product != null ? product.IdProduct : 0);

            var validate = new DeleteColorProductValidate(request, product, colorsByProduct);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await ColorProductQuery.DeleteColorsByProduct(validate.colorsDeleted, product.IdProduct);
            return ResultResponse(result);
        }
    }
}

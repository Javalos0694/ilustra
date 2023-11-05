using IlustraApp.Core.Bussiness.BProduct.Request;
using IlustraApp.Core.Bussiness.BProduct.Response;
using IlustraApp.Core.Bussiness.BProduct.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductRepository ProductRepository;
        private readonly IBaseRepository BaseRepository;
        public ProductController(IProductRepository productRepository, IBaseRepository baseRepository)
        {
            ProductRepository = productRepository;
            BaseRepository = baseRepository;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await ProductRepository.GetProducts();
            return Ok(new ProductsResponse(products));
        }

        [HttpGet]
        [Route("products/category")]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] int productCategory)
        {
            var products = await ProductRepository.GetProductsByCategory(productCategory);
            return Ok(new ProductsResponse(products));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var validate = new CreateProductValidate(request);
            var result = validate.ExecuteValidation();

            if (result.Code != Result.OK) return ResultResponse(result);

            await ProductRepository.CreateProduct(validate.NewProduct);
            await BaseRepository.SaveChangesAsync();
            result.Id = validate.NewProduct.IdProduct;
            return ResultResponse(result);
        }

        [HttpGet]
        [Route("{idProduct}")]
        public async Task<IActionResult> GetProductById(int idProduct)
        {
            var product = await ProductRepository.GetProductById(idProduct);
            if (product == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "product_not_found", Message = "Product not found." });

            return Ok(new ProductResponse(product));
        }

        [HttpPut]
        [Route("update/{idProduct}")]
        public async Task<IActionResult> UpdateProductById(int idProduct, [FromBody] UpdateProductRequest request)
        {
            var product = await ProductRepository.GetProductById(idProduct);
            var validate = new UpdateProductValidate(request, product);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) { return ResultResponse(result); }

            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPut]
        [Route("update/available/{idProduct}")]
        public async Task<IActionResult> ToogleProductAvailableStateById(int idProduct)
        {
            var product = await ProductRepository.GetProductById(idProduct);
            if (product == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "product_not_found", Message = "Product not found" });
            product.IsAvailable = !product.IsAvailable;
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result());
        }

        [HttpDelete]
        [Route("{idProduct}")]
        public async Task<IActionResult> DeleteProductById(int idProduct)
        {
            var product = await ProductRepository.GetProductById(idProduct);
            if (product == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "product_not_found", Message = "Product not found" });

            product.Deleted = true;
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result());
        }
    }
}

using IlustraApp.Core.Bussiness.BProductCategory.Request;
using IlustraApp.Core.Bussiness.BProductCategory.Response;
using IlustraApp.Core.Bussiness.BProductCategory.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController : BaseController
    {
        private readonly IProductRepository ProductRepository;
        private readonly IBaseRepository BaseRepository;
        public ProductCategoryController(IBaseRepository baseRepository, IProductRepository productRepository)
        {

            BaseRepository = baseRepository;
            ProductRepository = productRepository;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await ProductRepository.GetProductCategories();
            return Ok(new CategoriesResponse(categories));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProductCategory([FromBody] CreateProductCategoryRequest request)
        {
            var validate = new CreateProductCategoryValidate(request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await ProductRepository.CreateProductCategory(validate.NewProductCategory);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpGet]
        [Route("{idCategory}")]
        public async Task<IActionResult> GetCategoryById(int idCategory)
        {
            var category = await ProductRepository.GetProductCategoryById(idCategory);
            if (category == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "category_not_found", Message = "Category not found" });
            return Ok(new CategoryResponse(category));
        }

        [HttpPut]
        [Route("update/{idCategory}")]
        public async Task<IActionResult> UpdateCategory(int idCategory, [FromBody] UpdateProductCategoryRequest request)
        {
            var category = await ProductRepository.GetProductCategoryById(idCategory);
            var validate = new UpdateProductCategoryValidate(request, category);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) { return ResultResponse(result); }

            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpDelete]
        [Route("{idCategory}")]
        public async Task<IActionResult> DeleteProductCategory(int idCategory)
        {
            var category = await ProductRepository.GetProductCategoryById(idCategory);
            if (category == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "category_not_found", Message = "Category not found" });

            category.Deleted = true;
            await BaseRepository.SaveChangesAsync();
            return Ok(new Result());
        }
    }
}

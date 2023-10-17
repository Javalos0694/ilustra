using IlustraApp.Core.Bussiness.BProductCategory.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BProductCategory.Validate
{
    public class CreateProductCategoryValidate
    {
        private readonly CreateProductCategoryRequest Request;
        public ProductCategory NewProductCategory;
        public CreateProductCategoryValidate(CreateProductCategoryRequest request) => Request = request;

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                SetProductCategory();
            }
            return result;
        }

        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.Category)) return new Result { Code = Result.BAD_REQUEST, Type = "category_required", Message = "Category is required" };
            return new Result();
        }

        public void SetProductCategory()
        {
            NewProductCategory = new ProductCategory()
            {
                Category = Request.Category,
                Description = Request.Description,
            };
        }
    }
}

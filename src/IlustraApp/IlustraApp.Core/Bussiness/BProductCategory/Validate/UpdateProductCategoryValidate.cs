using IlustraApp.Core.Bussiness.BProductCategory.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BProductCategory.Validate
{
    public class UpdateProductCategoryValidate
    {
        private readonly UpdateProductCategoryRequest Request;
        private ProductCategory ProductCategory;
        public UpdateProductCategoryValidate(UpdateProductCategoryRequest request, ProductCategory productCategory)
        {
            Request = request;
            ProductCategory = productCategory;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateProductCategoryExists();
                if (result.Code == Result.OK)
                {
                    result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                    SetProductCategory();
                }
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.Category)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Category is required" };
            return new Result();
        }
        public Result ValidateProductCategoryExists()
        {
            if (ProductCategory == null) return new Result { Code = Result.NOT_FOUND, Type = "category_not_found", Message = "Category not found" };
            return new Result();
        }
        public void SetProductCategory()
        {
            ProductCategory.Category = Request.Category;
            ProductCategory.Description = Request.Description;
        }
    }
}

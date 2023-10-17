using IlustraApp.Core.Bussiness.BProduct.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BProduct.Validate
{
    public class CreateProductValidate
    {
        private readonly CreateProductRequest Request;
        public Product NewProduct;
        public CreateProductValidate(CreateProductRequest request) => Request = request;

        public Result ExecuteValidation()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = new Result() { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                SetProduct();
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.ProductName)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Product name is required" };
            if (Request.ProductCategory == 0) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Product category is required" };
            return new Result();
        }
        public void SetProduct()
        {
            NewProduct = new Product()
            {
                ProductName = Request.ProductName,
                IdProductCategory = Request.ProductCategory,
                IsAvailable = Request.IsAvailable,
                BasePrice = Request.BasePrice,
            };
        }
    }
}

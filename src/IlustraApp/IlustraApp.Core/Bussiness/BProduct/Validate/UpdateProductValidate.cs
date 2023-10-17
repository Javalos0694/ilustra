using IlustraApp.Core.Bussiness.BProduct.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BProduct.Validate
{
    public class UpdateProductValidate
    {
        private readonly UpdateProductRequest Request;
        private Product Product;
        public UpdateProductValidate(UpdateProductRequest request, Product product)
        {
            Request = request;
            Product = product;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateProductExists();
                if (result.Code == Result.OK)
                {
                    result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                    SetProduct();
                }
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.ProductName)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Product name is required" };
            if (Request.ProductCategory == 0) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Product category is required" };
            return new Result();
        }
        public Result ValidateProductExists()
        {
            if (Product == null) return new Result { Code = Result.NOT_FOUND, Type = "product_not_found", Message = "Product not found" };
            return new Result();
        }
        public void SetProduct()
        {
            Product.ProductName = Request.ProductName;
            Product.BasePrice = Request.BasePrice;
            Product.IsAvailable = Request.IsAvailable;
            Product.IdProductCategory = Request.ProductCategory;
        }
    }
}

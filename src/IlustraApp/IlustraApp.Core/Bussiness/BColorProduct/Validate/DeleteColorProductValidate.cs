using IlustraApp.Core.Bussiness.BColorProduct.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BColorProduct.Validate
{
    public class DeleteColorProductValidate
    {
        private readonly DeleteColorProductRequest Request;
        private readonly Product Product;
        private readonly List<ColorXproduct> ColorsByProduct;
        public int[] colorsDeleted;
        public DeleteColorProductValidate(DeleteColorProductRequest request, Product product, List<ColorXproduct> colorsByProduct)
        {
            Request = request;
            Product = product;
            ColorsByProduct = colorsByProduct;
        }
        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateProductExist();
                if (result.Code == Result.OK)
                {
                    SetColorsDeleted();
                    result = new Result { Code = Result.OK, Type = "save_changes", Message = Result.SUCCESSFULL_MESSAGE };
                }
            }
            return result;
        }

        public Result ValidateRequest()
        {
            if (Request.IdProduct == 0) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Invalid idProduct" };
            if (Request.Colors.Count == 0) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Needs associate atleast 1 color" };
            return new Result();
        }

        public Result ValidateProductExist()
        {
            if (Product == null) return new Result { Code = Result.NOT_FOUND, Type = "not_found", Message = "Product not found" };
            return new Result();
        }

        private void SetColorsDeleted()
        {
            if (ColorsByProduct.Count == 0) colorsDeleted = Array.Empty<int>();
            if (!ColorsByProduct.Any(x => !Request.Colors.Select(cr => cr.IdColor).Contains(x.IdColor))) colorsDeleted = Array.Empty<int>();

            colorsDeleted = ColorsByProduct.Where(x => !Request.Colors.Select(cr => cr.IdColor).Contains(x.IdColor)).Select(x=> x.IdColor).ToArray();
        }
    }
}

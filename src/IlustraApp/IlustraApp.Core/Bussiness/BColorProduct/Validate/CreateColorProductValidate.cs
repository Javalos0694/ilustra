using IlustraApp.Core.Bussiness.BColorProduct.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BColorProduct.Validate
{
    public class CreateColorProductValidate
    {
        private readonly CreateColorProductRequest Request;
        private readonly Product Product;
        public List<ColorXproduct> ColorsByProduct;
        private readonly List<ColorXproduct> ColorsByProductActual;
        public int[] ColorsDeleted;
        public CreateColorProductValidate(CreateColorProductRequest request, Product product, List<ColorXproduct> colorsByProductActual)
        {
            Request = request;
            Product = product;
            ColorsByProductActual = colorsByProductActual;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateProductExist();
                if (result.Code == Result.OK)
                {
                    result = new Result { Code = Result.OK, Type = "save_changes", Message = Result.SUCCESSFULL_MESSAGE };
                    DeleteColorsByProduct();
                    SetColorsByProduct();
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

        private void DeleteColorsByProduct()
        {
            if (ColorsByProductActual.Count == 0)
            {
                ColorsDeleted = Array.Empty<int>();
                return;
            }

            if (ColorsByProductActual.All(x => Request.Colors.Select(cr => cr.IdColor).Contains(x.IdColor)))
            {
                ColorsDeleted = Array.Empty<int>();
                return;
            }

            ColorsDeleted = ColorsByProductActual.Where(x => !Request.Colors.Select(cr => cr.IdColor).Contains(x.IdColor)).Select(x => x.IdColor).ToArray();
        }

        private void SetColorsByProduct()
        {
            ColorsByProduct = new();
            foreach (var color in Request.Colors)
            {
                if (!ColorsByProductActual.Any(x => x.IdColor == color.IdColor))
                {
                    ColorsByProduct.Add(new ColorXproduct() { IdColor = color.IdColor, IdProduct = Product.IdProduct });
                }
            }
        }
    }
}

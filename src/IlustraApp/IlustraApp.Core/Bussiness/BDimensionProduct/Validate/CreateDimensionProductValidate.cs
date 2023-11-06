using IlustraApp.Core.Bussiness.BDimensionProduct.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BDimensionProduct.Validate
{
    public class CreateDimensionProductValidate
    {
        private readonly Product Product;
        public List<DimensionXproduct> DimensionsProduct;
        private readonly List<DimensionXproduct> DimensionsByProductActual;
        private readonly CreateDimensionProductRequest Request;
        public int[] DimensionsDeleted;
        public CreateDimensionProductValidate(Product product, List<DimensionXproduct> dimensionByproducts, CreateDimensionProductRequest request)
        {
            Product = product;
            DimensionsByProductActual = dimensionByproducts;
            Request = request;
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
                    DeleteDimensionsByProduct();
                    SetDimensionsByProduct();
                }
            }
            return result;
        }

        public Result ValidateRequest()
        {
            if (Request.IdProduct == 0) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Invalid idProduct" };
            if (Request.Dimensions.Count == 0) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Needs associate atleast 1 dimension" };
            return new Result();
        }

        public Result ValidateProductExist()
        {
            if (Product == null) return new Result { Code = Result.NOT_FOUND, Type = "not_found", Message = "Product not found" };
            return new Result();
        }

        private void DeleteDimensionsByProduct()
        {
            if (DimensionsByProductActual.Count == 0)
            {
                DimensionsDeleted = Array.Empty<int>();
                return;
            }

            if (DimensionsByProductActual.All(x => Request.Dimensions.Select(dr => dr.IdDimension).Contains(x.IdDimension)))
            {
                DimensionsDeleted = Array.Empty<int>();
                return;
            }

            DimensionsDeleted = DimensionsByProductActual.Where(x => !Request.Dimensions.Select(dr => dr.IdDimension).Contains(x.IdDimension)).Select(x => x.IdDimension).ToArray();
        }

        private void SetDimensionsByProduct()
        {
            DimensionsProduct = new();
            foreach (var dimension in Request.Dimensions)
            {
                if (!DimensionsByProductActual.Any(x => x.IdDimension == dimension.IdDimension))
                {
                    DimensionsProduct.Add(new DimensionXproduct() { IdDimension = dimension.IdDimension, IdProduct = Product.IdProduct });
                }
            }
        }
    }
}

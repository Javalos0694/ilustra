using IlustraApp.Core.Bussiness.BDimension.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BDimension.Validate
{
    public class UpdateDimensionValidate
    {
        private readonly Dimension DimensionUpdated;
        private readonly UpdateDimensionRequest Request;
        public UpdateDimensionValidate(Dimension dimensionUpdated, UpdateDimensionRequest request)
        {
            DimensionUpdated = dimensionUpdated;
            Request = request;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateDimensionExist();
                if (result.Code == Result.OK)
                {
                    SetDimension();
                    result = new Result { Code = Result.OK, Type = "save_changes", Message = Result.SUCCESSFULL_MESSAGE };
                }
            }
            return result;
        }

        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.DimensionName)) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Dimension name is required" };
            if (string.IsNullOrEmpty(Request.DimensionCode)) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Dimension code is required" };
            return new Result();
        }

        public Result ValidateDimensionExist()
        {
            if (DimensionUpdated == null) return new Result { Code = Result.NOT_FOUND, Type = "dimension_not_found", Message = "Dimension not found" };
            return new Result();
        }

        private void SetDimension()
        {
            DimensionUpdated.DimensionName = Request.DimensionName;
            DimensionUpdated.DimensionCode = Request.DimensionCode;
            DimensionUpdated.BasePrice = Request.BasePrice;
            DimensionUpdated.IsAvailable = Request.IsAvailable;
        }
    }
}

using IlustraApp.Core.Bussiness.BDimension.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BDimension.Validate
{
    public class CreateDimensionValidate
    {
        private readonly CreateDimensionRequest Request;
        public Dimension newDimension;
        public CreateDimensionValidate(CreateDimensionRequest request) => Request = request;

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                SetDimension();
                result = new Result { Code = Result.OK, Type = "save_changes", Message = Result.SUCCESSFULL_MESSAGE };
            }
            return result;
        }

        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.DimensionName)) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Dimension name is required" };
            if (string.IsNullOrEmpty(Request.DimensionCode)) return new Result { Code = Result.BAD_REQUEST, Type = "bad_request", Message = "Dimension code is required" };
            return new Result();
        }

        private void SetDimension()
        {
            newDimension = new Dimension()
            {
                DimensionName = Request.DimensionName,
                DimensionCode = Request.DimensionCode,
                BasePrice = Request.BasePrice,
                IsAvailable = Request.IsAvailable,
            };
        }
    }
}

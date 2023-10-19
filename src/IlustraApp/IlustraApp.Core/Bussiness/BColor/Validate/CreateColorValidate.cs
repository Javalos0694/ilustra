using IlustraApp.Core.Bussiness.BColor.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BColor.Validate
{
    public class CreateColorValidate
    {
        private readonly CreateColorRequest Request;
        public Color NewColor;
        public CreateColorValidate(CreateColorRequest request)
        {
            Request = request;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                SetColor();
            }

            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.ColorName)) return new Result { Code = Result.BAD_REQUEST, Type = "colorName_required", Message = "Color name is required" };
            return new Result();
        }
        public void SetColor()
        {
            NewColor = new Color()
            {
                ColorName = Request.ColorName,
                BasePrice = Request.BasePrice,
                IsAvailable = Request.IsAvailable,
                ColorCode = Request.ColorCode
            };
        }
    }
}

using IlustraApp.Core.Bussiness.BColor.Request;
using IlustraApp.Core.Entities;
using Services;

namespace IlustraApp.Core.Bussiness.BColor.Validate
{
    public class UpdateColorValidate
    {
        private readonly UpdateColorRequest Request;
        private readonly Color ColorUpdated;
        public UpdateColorValidate(UpdateColorRequest request, Color color)
        {
            Request = request;
            ColorUpdated = color;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateColorExists();
                if (result.Code == Result.OK)
                {
                    result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                    SetColor();
                }
            }

            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.ColorName)) return new Result { Code = Result.BAD_REQUEST, Type = "colorName_required", Message = "Color name is required" };
            return new Result();
        }
        public Result ValidateColorExists()
        {
            if (ColorUpdated == null) return new Result { Code = Result.NOT_FOUND, Type = "color_not_found", Message = "Color not found" };
            return new Result();
        }
        public void SetColor()
        {
            ColorUpdated.ColorName = Request.ColorName;
            ColorUpdated.BasePrice = Request.BasePrice;
            ColorUpdated.IsAvailable = Request.IsAvailable;
            ColorUpdated.ColorCode = Request.ColorCode;
        }
    }
}

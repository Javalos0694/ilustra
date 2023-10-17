using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ResultResponse(Result result)
        {
            if (result == null)
                result = new Result();

            return result.Code switch
            {
                Result.OK => Ok(result),
                Result.BAD_REQUEST => BadRequest(result),
                Result.NOT_FOUND => NotFound(result),
                Result.UNAUTHORIZED => Unauthorized(result),
                Result.SERVER_ERROR => StatusCode(500, result),
                _ => Ok(result),
            };
        }
    }
}

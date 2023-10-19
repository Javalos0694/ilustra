using Microsoft.AspNetCore.Mvc;
using Services;
using System.IdentityModel.Tokens.Jwt;

namespace IlustrApp.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string Token
        {
            get
            {
                var schemaAuthentication = "Bearer";
                return Request.Headers["Authorization"].ToString().Substring(schemaAuthentication.Length + 1);
            }
        }

        protected int IdLoggedUser
        {
            get
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.ReadToken(Token) as JwtSecurityToken;

                var claim = token.Claims.FirstOrDefault(x => x.Type == "IdUser").Value;
                if (!string.IsNullOrEmpty(claim))
                    return int.Parse(claim);
                return 0;
            }
        }

        protected int IdPerson
        {
            get
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.ReadToken(Token) as JwtSecurityToken;

                var claim = token.Claims.FirstOrDefault(x => x.Type == "IdPerson").Value;
                if (!string.IsNullOrEmpty(claim))
                    return int.Parse(claim);
                return 0;
            }
        }

        protected int Perfil
        {
            get
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.ReadToken(Token) as JwtSecurityToken;

                var claim = token.Claims.FirstOrDefault(x => x.Type == "Perfil").Value;
                if (!string.IsNullOrEmpty(claim))
                    return int.Parse(claim);
                return 0;
            }
        }

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

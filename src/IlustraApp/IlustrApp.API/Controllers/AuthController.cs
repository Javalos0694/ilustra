using IlustraApp.Core.Bussiness.Auth.Request;
using IlustraApp.Core.Bussiness.Auth.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Security;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IBaseRepository BaseRepository;
        private readonly IUserRepository UserRepository;
        private readonly IConfiguration Configuration;
        public AuthController(IBaseRepository baseRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            BaseRepository = baseRepository;
            UserRepository = userRepository;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await UserRepository.FindUserByUsername(request.Username ?? "");
            var validate = new LoginValidate(request, user);

            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK)
                return ResultResponse(result);

            var token = SecurityToken.BuildToken(user.Username, user.IdPerson, user.IdUser, user.IdUserType, Configuration["Security:Token"]);

            return Ok(new
            {
                Code = Result.OK,
                user.Username,
                token,
            });
        }

        //Falta implementar mensaje de correo para recuperacion de contraseña
        [HttpPost]
        [Route("password/recovery")]
        public async Task<IActionResult> RecoveryPassword([FromBody] RecoveryPasswordRequest request)
        {
            var user = await UserRepository.FindUserByUsername(request.Username ?? "");
            var validate = new RecoveryPasswordValidate(user, request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await BaseRepository.SaveChangesAsync();

            return Ok(new
            {
                validate.newPassword,
                validate.User.RecoveryPasswordCode
            });
        }

        [HttpGet]
        [Route("password/change/{recoveryCode}")]
        public async Task<IActionResult> ChangePassword([FromQuery] string recoveryCode, [FromBody] string password)
        {
            var user = await UserRepository.FindUserByCode(recoveryCode);
            if (user == null)
                return ResultResponse(new Result { Code = Result.BAD_REQUEST, Type = "wrong_code", Message = "Wrong recovery code" });

            user.RecoveryPasswordCode = null;
            user.Password = Crypto.HashPassword(password);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE });
        }
    }
}

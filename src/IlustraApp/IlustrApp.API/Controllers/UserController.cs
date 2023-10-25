using IlustraApp.Core.Bussiness.BUser.Request;
using IlustraApp.Core.Bussiness.BUser.Response;
using IlustraApp.Core.Bussiness.BUser.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository UserRepository;
        private readonly IPersonRepository PersonRepository;
        private readonly IBaseRepository BaseRepository;
        public UserController(IUserRepository userRepository, IBaseRepository baseRepository, IPersonRepository personRepository)
        {
            UserRepository = userRepository;
            BaseRepository = baseRepository;
            PersonRepository = personRepository;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await UserRepository.FindAll();
            return Ok(new UsersResponse(users));
        }

        [HttpGet]
        [Route("{idUser}")]
        public async Task<IActionResult> GetUserById(int idUser)
        {
            var user = await UserRepository.FindUserById(idUser);
            if (user == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "user_not_found", Message = "User not found" });
            return Ok(new UserResponse(user));
        }

        [HttpGet]
        [Route("account")]
        public async Task<IActionResult> GetUserByToken()
        {
            var user = await UserRepository.FindUserById(IdLoggedUser);
            if(user == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "user_not_found", Message = "User not found" });
            return Ok(new UserResponse(user));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var validate = new CreateUserValidate(request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await PersonRepository.CreatePerson(validate.NewPerson);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPut]
        [Route("update/{idUser}")]
        public async Task<IActionResult> UpdateUser(int idUser, [FromBody] UpdateUserRequest request)
        {
            var user = await UserRepository.FindUserById(idUser);
            var validate = new UpdateUserValidate(request, user);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpDelete]
        [Route("delete/{idUser}")]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var user = await UserRepository.FindUserById(idUser);
            if (user == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "user_not_found", Message = "User not found" });
            user.Deleted = true;
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result());
        }

    }
}

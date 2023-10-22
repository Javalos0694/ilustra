using IlustraApp.Core.Bussiness.Auth.Request;
using IlustraApp.Core.Entities;
using Security;
using Services;

namespace IlustraApp.Core.Bussiness.Auth.Validate
{
    public class LoginValidate
    {
        private readonly LoginRequest Request;
        private readonly User UserValidate;
        public LoginValidate(LoginRequest request, User userValidate)
        {
            Request = request;
            UserValidate = userValidate;
        }
        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateUserExist();
                if (result.Code == Result.OK)
                {
                    result = ValidatePassword();
                }
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.Username))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Message = "Username is required",
                    Type = "user_required"
                };
            }

            if (string.IsNullOrEmpty(Request.Password))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Message = "Password is required",
                    Type = "password_required"
                };
            }
            return new Result();
        }
        public Result ValidateUserExist()
        {
            if (UserValidate == null)
            {
                return new Result
                {
                    Code = Result.NOT_FOUND,
                    Type = "user_not_found",
                    Message = "User not found"
                };
            }

            return new Result();
        }
        public Result ValidatePassword()
        {
            if (!Crypto.VerifyPassword(Request.Password ?? "", UserValidate.Password))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Type = "invalid_password",
                    Message = "Invalid password"
                };
            }
            return new Result();
        }

    }
}

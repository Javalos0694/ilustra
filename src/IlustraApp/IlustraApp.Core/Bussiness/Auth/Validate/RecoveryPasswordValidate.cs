using IlustraApp.Core.Bussiness.Auth.Request;
using IlustraApp.Core.Entities;
using Security;
using Services;
using System.Text.RegularExpressions;

namespace IlustraApp.Core.Bussiness.Auth.Validate
{
    public class RecoveryPasswordValidate
    {
        public User? User;
        public string newPassword = "";
        private readonly RecoveryPasswordRequest Request;

        public RecoveryPasswordValidate(User user, RecoveryPasswordRequest request)
        {
            User = user;
            Request = request;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateUserExist();
                if (result.Code == Result.OK)
                {
                    result = ValidateEmail();
                    if (result.Code == Result.OK)
                    {
                        SetNewPassword();
                        SetRecoveryCode();
                    }
                }
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrWhiteSpace(Request.Username))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Type = "user_required",
                    Message = "User required"
                };
            }

            if (string.IsNullOrWhiteSpace(Request.Email))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Type = "email_required",
                    Message = "Email required"
                };
            }
            return new Result();
        }
        public Result ValidateUserExist()
        {
            if (User == null)
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
        public Result ValidateEmail()
        {
            string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            if (!Regex.IsMatch(Request.Email ?? "", pattern))
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Type = "email_invalid_format",
                    Message = "Invalid format email"
                };
            }

            if (Request.Email != User.IdPersonNavigation.Email)
            {
                return new Result
                {
                    Code = Result.BAD_REQUEST,
                    Type = "wrong_data",
                    Message = "Wrong Email for this user"
                };
            }

            return new Result();
        }
        public void SetNewPassword()
        {
            newPassword = StringHelper.GeneratePassword(10, 2);
            User.LastPassword = User.Password;
            User.Password = Crypto.HashPassword(newPassword);
            User.UpdatedAt = DateTime.UtcNow.AddHours(-5);
        }
        public void SetRecoveryCode()
        {
            User.RecoveryPasswordCode = StringHelper.GenerateUniqueCode();
        }
    }
}

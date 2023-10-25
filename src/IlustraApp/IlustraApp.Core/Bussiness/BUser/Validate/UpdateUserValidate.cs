using IlustraApp.Core.Bussiness.BUser.Request;
using IlustraApp.Core.Entities;
using Security;
using Services;
using System.Text.RegularExpressions;

namespace IlustraApp.Core.Bussiness.BUser.Validate
{
    public class UpdateUserValidate
    {
        private readonly User User;
        private readonly UpdateUserRequest Request;
        public UpdateUserValidate(UpdateUserRequest request, User user)
        {
            Request = request;
            User = user;
        }

        public Result ExecuteValidations()
        {
            var result = ValidateRequest();
            if (result.Code == Result.OK)
            {
                result = ValidateEmail();
                if (result.Code == Result.OK)
                {
                    result = ValidatePassword();
                    if (result.Code == Result.OK)
                    {
                        result = ValidateEmail();
                        if (result.Code == Result.OK)
                        {
                            result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                            SetPerson();
                        }
                    }
                }
            }
            return result;
        }
        public Result ValidateRequest()
        {
            if (string.IsNullOrEmpty(Request.FirstName)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Firstname is required" };
            if (string.IsNullOrEmpty(Request.LastName)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Lastname is required" };
            if (string.IsNullOrEmpty(Request.Email)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Email is required" };
            if (string.IsNullOrEmpty(Request.PhoneNumber)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Phone number is required" };
            if (Request.DocumentType == 0) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Document type is required" };
            if (string.IsNullOrEmpty(Request.DocumentNumber)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Document number is required" };
            return new Result();
        }
        public Result ValidateUserExists()
        {
            if (User == null) return new Result { Code = Result.NOT_FOUND, Type = "user_not_found", Message = "User not found" };
            return new Result();
        }
        public Result ValidatePassword()
        {
            if (!string.IsNullOrEmpty(Request.Password))
                if (!StringHelper.IsCorrectPasswordFormat(Request.Password ?? "")) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Invalid format password" };
            return new Result();
        }
        public Result ValidateEmail()
        {
            string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            if (!Regex.IsMatch(Request.Email ?? "", pattern)) return new Result { Code = Result.BAD_REQUEST, Type = "email_invalid_format", Message = "Invalid format email" };

            return new Result();
        }
        public void SetPerson()
        {
            User.IdUserType = Request.UserType;
            User.Password = string.IsNullOrEmpty(Request.Password) ? User.Password : Crypto.HashPassword(Request.Password);
            User.IdPersonNavigation.FirstName = Request.FirstName;
            User.IdPersonNavigation.LastName = Request.LastName;
            User.IdPersonNavigation.DocumentNumber = Request.DocumentNumber;
            User.IdPersonNavigation.IdDocumentType = Request.DocumentType;
            User.IdPersonNavigation.Address = Request.Address;
            User.IdPersonNavigation.BornDate = Request.BornDate;
            User.IdPersonNavigation.Email = Request.Email;
        }
    }
}

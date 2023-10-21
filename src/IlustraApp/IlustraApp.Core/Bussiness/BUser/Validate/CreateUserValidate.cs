using IlustraApp.Core.Bussiness.BUser.Request;
using IlustraApp.Core.Entities;
using Security;
using Services;
using System.Text.RegularExpressions;

namespace IlustraApp.Core.Bussiness.BUser.Validate
{
    public class CreateUserValidate
    {
        private readonly CreateUserRequest Request;
        public Person NewPerson;
        public CreateUserValidate(CreateUserRequest request) => Request = request;

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
                        result = new Result { Code = Result.OK, Type = "changes_saved", Message = Result.SUCCESSFULL_MESSAGE };
                        SetPerson();
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
            if (Request.BornDate == null) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Born date is required" };
            if (string.IsNullOrEmpty(Request.Username)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Username is required" };
            if (string.IsNullOrEmpty(Request.Password)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Password is required" };
            return new Result();
        }
        public Result ValidatePassword()
        {
            if (!StringHelper.IsCorrectPasswordFormat(Request.Password)) return new Result { Code = Result.BAD_REQUEST, Type = "wrong_data", Message = "Invalid format password" };
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
            NewPerson = new Person
            {
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                IdDocumentType = Request.DocumentType,
                DocumentNumber = Request.DocumentNumber,
                PhoneNumber = Request.PhoneNumber,
                Email = Request.Email,
                BornDate = Request.BornDate.Value,
                Address = Request.Address,
                User = new List<User>
                {
                    new User
                    {
                        Username = Request.Username,
                        Password = Crypto.HashPassword(Request.Password),
                        IdUserType = Request.UserType
                    }
                }
            };
        }
    }
}

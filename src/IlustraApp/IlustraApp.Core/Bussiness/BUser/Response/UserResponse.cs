using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BUser.Response
{
    public class UserResponse
    {
        public int IdUser { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BornDate { get; set; }
        public UserResponse(User user)
        {
            IdUser = user.IdUser;
            UserType = user.IdUserType;
            UserName = user.Username;
            Password = user.Password;
            FirstName = user.IdPersonNavigation.FirstName;
            LastName = user.IdPersonNavigation.LastName;
            BornDate = user.IdPersonNavigation.BornDate;
            DocumentType = user.IdPersonNavigation.IdDocumentType;
            DocumentNumber = user.IdPersonNavigation.DocumentNumber;
            Email = user.IdPersonNavigation.Email;
            Address = user.IdPersonNavigation.Address;
        }
    }
}

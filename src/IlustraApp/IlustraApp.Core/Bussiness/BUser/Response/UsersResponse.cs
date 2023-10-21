using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BUser.Response
{
    public class UsersResponse
    {
        public List<UserResponseClass> Users { get; set; }
        public int Total { get; set; }
        public UsersResponse(List<User> users)
        {
            Users = new();
            foreach (var user in users)
            {
                Users.Add(new UserResponseClass(user));
            }
            Total = Users.Count;
        }
    }

    public class UserResponseClass
    {
        public int IdUser { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public UserResponseClass(User user)
        {
            IdUser = user.IdUser;
            UserType = user.IdUserType;
            Username = user.Username;
        }
    }
}

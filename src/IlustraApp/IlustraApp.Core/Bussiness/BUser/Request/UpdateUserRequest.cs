namespace IlustraApp.Core.Bussiness.BUser.Request
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BornDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; } = null;
        public int UserType { get; set; }
    }
}

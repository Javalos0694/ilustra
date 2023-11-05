
namespace Services
{
    public class Result
    {
        public int? Id { get; set; }
        public int Code { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
        public Result()
        {
            Code = OK;
        }

        public const int OK = 200;
        public const int BAD_REQUEST = 400;
        public const int UNAUTHORIZED = 401;
        public const int NOT_FOUND = 404;
        public const int SERVER_ERROR = 500;
        public const string SUCCESSFULL_MESSAGE = "Save changes sucessfully";
    }
}
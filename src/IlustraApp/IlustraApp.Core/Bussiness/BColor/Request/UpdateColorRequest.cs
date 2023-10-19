namespace IlustraApp.Core.Bussiness.BColor.Request
{
    public class UpdateColorRequest
    {
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}

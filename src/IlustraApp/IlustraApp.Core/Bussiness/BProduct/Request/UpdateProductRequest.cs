namespace IlustraApp.Core.Bussiness.BProduct.Request
{
    public class UpdateProductRequest
    {
        public int IdProductCategory { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}

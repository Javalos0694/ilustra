using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BProduct.Response
{
    public class ProductResponse
    {
        public int IdProduct { get; set; }
        public int IdProductCategory { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public ProductResponse(Product product)
        {
            IdProduct = product.IdProduct;
            IdProductCategory = product.IdProductCategory;
            ProductName = product.ProductName;
            Description = product.Description;
            BasePrice = product.BasePrice;
            IsAvailable = product.IsAvailable;
        }
    }
}

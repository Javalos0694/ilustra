using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BProduct.Response
{
    public class ProductsResponse
    {
        public List<dynamic> Products { set; get; }
        public int Total { set; get; }
        public ProductsResponse(IEnumerable<dynamic> products)
        {
            Products = new List<dynamic>();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            Total = products.Count();
        }
    }

    public class ProductClass
    {
        public int IdProduct { get; set; }
        public int IdProductCategory { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public ProductClass(dynamic product)
        {
            IdProduct = product.IdProduct;
            IdProductCategory = product.IdProductCategory;
            ProductName = product.ProductName;
            Description = product.Description;
            BasePrice = product.BasePrice;
            IsAvailable = product.IsAvailable;
            Category = product.Category;
        }
    }
}

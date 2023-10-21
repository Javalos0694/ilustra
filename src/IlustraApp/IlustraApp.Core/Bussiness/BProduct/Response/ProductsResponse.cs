﻿using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BProduct.Response
{
    public class ProductsResponse
    {
        public List<ProductClass> Products;
        public int Total;
        public ProductsResponse(List<Product> products)
        {
            Products = new List<ProductClass>();
            foreach (var product in products)
            {
                Products.Add(new ProductClass(product));
            }
            Total = products.Count;
        }
    }

    public class ProductClass
    {
        public int IdProduct { get; set; }
        public int IdProductCategory { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public ProductClass(Product product)
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

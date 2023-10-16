using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            FileProduct = new HashSet<FileProduct>();
            InverseIdProductCategoryNavigation = new HashSet<Product>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int IdProduct { get; set; }
        public int IdProductCategory { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Product IdProductCategoryNavigation { get; set; } = null!;
        public virtual ICollection<FileProduct> FileProduct { get; set; }
        public virtual ICollection<Product> InverseIdProductCategoryNavigation { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}

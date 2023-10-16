using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            Sale = new HashSet<Sale>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int IdShoppingCart { get; set; }
        public int IdUser { get; set; }
        public string ShoppingCartCode { get; set; } = null!;
        public decimal TotalMount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class ShoppingCartItem
    {
        public int IdShoppingCartItem { get; set; }
        public int IdShoppingCart { get; set; }
        public int? IdProduct { get; set; }
        public int? IdDesign { get; set; }
        public int? IdColor { get; set; }
        public int? IdDimension { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Color? IdColorNavigation { get; set; }
        public virtual Design? IdDesignNavigation { get; set; }
        public virtual Dimension? IdDimensionNavigation { get; set; }
        public virtual Product? IdProductNavigation { get; set; }
        public virtual ShoppingCart IdShoppingCartNavigation { get; set; } = null!;
    }
}

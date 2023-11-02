using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Dimension
    {
        public Dimension()
        {
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int IdDimension { get; set; }
        public string DimensionName { get; set; } = null!;
        public string DimensionCoode { get; set; } = null!;
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Color
    {
        public Color()
        {
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int IdColor { get; set; }
        public string ColorName { get; set; } = null!;
        public string ColorCode { get; set; } = null!;
        public decimal BasePrice { get; set; }
        public byte[] ImageColor { get; set; } = null!;
        public bool? IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Sale
    {
        public int IdSale { get; set; }
        public int IdShoppingCart { get; set; }
        public string CodeSale { get; set; } = null!;
        public int IdStatusSale { get; set; }
        public int IdPayMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual PayMethod IdPayMethodNavigation { get; set; } = null!;
        public virtual ShoppingCart IdShoppingCartNavigation { get; set; } = null!;
        public virtual StatusSale IdStatusSaleNavigation { get; set; } = null!;
    }
}

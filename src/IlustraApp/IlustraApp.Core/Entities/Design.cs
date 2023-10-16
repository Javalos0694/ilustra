using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Design
    {
        public Design()
        {
            DesignProduct = new HashSet<DesignProduct>();
            FileDesign = new HashSet<FileDesign>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int IdDesign { get; set; }
        public int IdAlly { get; set; }
        public int IdProductCategory { get; set; }
        public string DesignName { get; set; } = null!;
        public string? DesignDescription { get; set; }
        public string? DesignPresentation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Ally IdAllyNavigation { get; set; } = null!;
        public virtual ProductCategory IdProductCategoryNavigation { get; set; } = null!;
        public virtual ICollection<DesignProduct> DesignProduct { get; set; }
        public virtual ICollection<FileDesign> FileDesign { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}

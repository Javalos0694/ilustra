using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class DesignProduct
    {
        public int IdDesignProduct { get; set; }
        public int IdDesign { get; set; }
        public int IdProductCategory { get; set; }
        public decimal BasePrice { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Design IdDesignNavigation { get; set; } = null!;
        public virtual ProductCategory IdProductCategoryNavigation { get; set; } = null!;
    }
}

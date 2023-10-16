using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class DimensionXproduct
    {
        public int IdDimension { get; set; }
        public int IdProduct { get; set; }

        public virtual Dimension IdDimensionNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}

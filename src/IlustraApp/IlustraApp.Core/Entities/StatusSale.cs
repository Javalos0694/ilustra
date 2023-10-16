using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class StatusSale
    {
        public StatusSale()
        {
            Sale = new HashSet<Sale>();
        }

        public int IdStatusSale { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}

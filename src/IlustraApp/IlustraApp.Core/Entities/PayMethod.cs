using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class PayMethod
    {
        public PayMethod()
        {
            Sale = new HashSet<Sale>();
        }

        public int IdPayMethod { get; set; }
        public string NameMethod { get; set; } = null!;
        public string? DescriptionMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}

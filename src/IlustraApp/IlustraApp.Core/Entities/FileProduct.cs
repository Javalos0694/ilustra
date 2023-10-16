using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class FileProduct
    {
        public int IdFileProduct { get; set; }
        public int IdProduct { get; set; }
        public string FileName { get; set; } = null!;
        public byte[] ProductImage { get; set; } = null!;
        public string CodeFile { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}

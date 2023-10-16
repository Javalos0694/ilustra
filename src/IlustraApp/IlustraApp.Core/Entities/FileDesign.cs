using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class FileDesign
    {
        public int IdFileDesign { get; set; }
        public int IdDesign { get; set; }
        public string FileName { get; set; } = null!;
        public string CodeFile { get; set; } = null!;
        public byte[] DesignFimage { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Design IdDesignNavigation { get; set; } = null!;
    }
}

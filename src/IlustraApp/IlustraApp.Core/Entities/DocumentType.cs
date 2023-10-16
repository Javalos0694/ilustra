using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Person = new HashSet<Person>();
        }

        public int IdDocumentType { get; set; }
        public string DocumentName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Person
    {
        public Person()
        {
            User = new HashSet<User>();
        }

        public int IdPerson { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int IdDocumentType { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BornDate { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual DocumentType IdDocumentTypeNavigation { get; set; } = null!;
        public virtual ICollection<User> User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int IdUserType { get; set; }
        public string UserType1 { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}

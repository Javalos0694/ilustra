using System;
using System.Collections.Generic;

namespace IlustraApp.Core.Entities
{
    public partial class Ally
    {
        public Ally()
        {
            Design = new HashSet<Design>();
        }

        public int IdAlly { get; set; }
        public int IdUser { get; set; }
        public string? ComercialName { get; set; }
        public string? BussinessName { get; set; }
        public string? BussinessDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Design> Design { get; set; }
    }
}

namespace IlustraApp.Core.Entities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Design = new HashSet<Design>();
            DesignProduct = new HashSet<DesignProduct>();
        }

        public int IdProductCategory { get; set; }
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Design> Design { get; set; }
        public virtual ICollection<DesignProduct> DesignProduct { get; set; }
    }
}

namespace IlustraApp.Core.Entities
{
    public partial class ColorXproduct
    {
        public int IdColorProduct { get; set; }
        public int IdColor { get; set; }
        public int IdProduct { get; set; }

        public virtual Color IdColorNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}

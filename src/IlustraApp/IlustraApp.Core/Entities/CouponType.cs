namespace IlustraApp.Core.Entities
{
    public partial class CouponType
    {
        public CouponType()
        {
            Coupon = new HashSet<Coupon>();
        }

        public int IdCouponType { get; set; }
        public string CouponTypeName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Coupon> Coupon { get; set; }
    }
}

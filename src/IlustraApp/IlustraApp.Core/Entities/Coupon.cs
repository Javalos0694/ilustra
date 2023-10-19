namespace IlustraApp.Core.Entities
{
    public partial class Coupon
    {
        public int IdCoupon { get; set; }
        public int IdCouponType { get; set; }
        public string CouponName { get; set; } = null!;
        public string CouponCode { get; set; } = null!;
        public int? IdUser { get; set; }
        public decimal CouponValue { get; set; }
        public int UseQuantity { get; set; }
        public int LimitQuantityUse { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual CouponType IdCouponTypeNavigation { get; set; } = null!;
        public virtual User? IdUserNavigation { get; set; }
    }
}

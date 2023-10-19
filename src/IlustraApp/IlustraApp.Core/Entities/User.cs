namespace IlustraApp.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Ally = new HashSet<Ally>();
            Coupon = new HashSet<Coupon>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdUserType { get; set; }
        public string? RecoveryPasswordCode { get; set; }
        public string? LastPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        public virtual Person IdPersonNavigation { get; set; } = null!;
        public virtual UserType IdUserTypeNavigation { get; set; } = null!;
        public virtual ICollection<Ally> Ally { get; set; }
        public virtual ICollection<Coupon> Coupon { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}

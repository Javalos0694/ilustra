using IlustraApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IlustraApp.Infrastructure.Data
{
    public partial class IlustraContext : DbContext
    {
        public IlustraContext()
        {
        }

        public IlustraContext(DbContextOptions<IlustraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ally> Ally { get; set; } = null!;
        public virtual DbSet<Color> Color { get; set; } = null!;
        public virtual DbSet<ColorXproduct> ColorXproduct { get; set; } = null!;
        public virtual DbSet<Coupon> Coupon { get; set; } = null!;
        public virtual DbSet<CouponType> CouponType { get; set; } = null!;
        public virtual DbSet<Design> Design { get; set; } = null!;
        public virtual DbSet<DesignProduct> DesignProduct { get; set; } = null!;
        public virtual DbSet<Dimension> Dimension { get; set; } = null!;
        public virtual DbSet<DimensionXproduct> DimensionXproduct { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentType { get; set; } = null!;
        public virtual DbSet<FileDesign> FileDesign { get; set; } = null!;
        public virtual DbSet<FileProduct> FileProduct { get; set; } = null!;
        public virtual DbSet<PayMethod> PayMethod { get; set; } = null!;
        public virtual DbSet<Person> Person { get; set; } = null!;
        public virtual DbSet<Product> Product { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } = null!;
        public virtual DbSet<Sale> Sale { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; } = null!;
        public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; } = null!;
        public virtual DbSet<StatusSale> StatusSale { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserType> UserType { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ally>(entity =>
            {
                entity.HasKey(e => e.IdAlly)
                    .HasName("PK_idAlly");

                entity.Property(e => e.IdAlly).HasColumnName("idAlly");

                entity.Property(e => e.BussinessDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("bussinessDescription");

                entity.Property(e => e.BussinessName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bussinessName");

                entity.Property(e => e.ComercialName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("comercialName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ally)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Ally");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PK_IdColor");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.BasePrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("basePrice");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("colorCode");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("colorName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ImageColor).HasColumnName("imageColor");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ColorXproduct>(entity =>
            {
                entity.HasKey(e => e.IdColorProduct)
                    .HasName("PK_ColorProduct");

                entity.Property(e => e.IdColorProduct).HasColumnName("idColorProduct");

                entity.ToTable("ColorXProduct");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Color_Product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Color");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasKey(e => e.IdCoupon)
                    .HasName("PK_idCoupon");

                entity.HasIndex(e => e.CouponName, "UQ__Coupon__DC24DC873E8A8A8D")
                    .IsUnique();

                entity.Property(e => e.IdCoupon).HasColumnName("idCoupon");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("couponCode");

                entity.Property(e => e.CouponName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("couponName");

                entity.Property(e => e.CouponValue)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("couponValue");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expirationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCouponType).HasColumnName("idCouponType");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimitQuantityUse).HasColumnName("limitQuantityUse");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UseQuantity).HasColumnName("useQuantity");

                entity.HasOne(d => d.IdCouponTypeNavigation)
                    .WithMany(p => p.Coupon)
                    .HasForeignKey(d => d.IdCouponType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouponType_Coupon");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Coupon)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Coupon_User");
            });

            modelBuilder.Entity<CouponType>(entity =>
            {
                entity.HasKey(e => e.IdCouponType)
                    .HasName("PK_idCouponTpye");

                entity.Property(e => e.IdCouponType).HasColumnName("idCouponType");

                entity.Property(e => e.CouponTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("couponTypeName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.HasKey(e => e.IdDesign)
                    .HasName("PK_idDesign");

                entity.Property(e => e.IdDesign).HasColumnName("idDesign");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DesignDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("designDescription");

                entity.Property(e => e.DesignName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("designName");

                entity.Property(e => e.DesignPresentation)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("designPresentation");

                entity.Property(e => e.IdAlly).HasColumnName("idAlly");

                entity.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdAllyNavigation)
                    .WithMany(p => p.Design)
                    .HasForeignKey(d => d.IdAlly)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ally_Design");

                entity.HasOne(d => d.IdProductCategoryNavigation)
                    .WithMany(p => p.Design)
                    .HasForeignKey(d => d.IdProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Design_ProductCategory");
            });

            modelBuilder.Entity<DesignProduct>(entity =>
            {
                entity.HasKey(e => e.IdDesignProduct)
                    .HasName("PK_idDesignProduct");

                entity.Property(e => e.IdDesignProduct).HasColumnName("idDesignProduct");

                entity.Property(e => e.BasePrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("basePrice");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdDesign).HasColumnName("idDesign");

                entity.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDesignNavigation)
                    .WithMany(p => p.DesignProduct)
                    .HasForeignKey(d => d.IdDesign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Design_DesignProduct");

                entity.HasOne(d => d.IdProductCategoryNavigation)
                    .WithMany(p => p.DesignProduct)
                    .HasForeignKey(d => d.IdProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_DesignProduct");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.HasKey(e => e.IdDimension)
                    .HasName("PK_idDimension");

                entity.Property(e => e.IdDimension).HasColumnName("idDimension");

                entity.Property(e => e.BasePrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("basePrice");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DimensionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dimensionCode");

                entity.Property(e => e.DimensionName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dimensionName");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DimensionXproduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DimensionXProduct");

                entity.Property(e => e.IdDimension).HasColumnName("idDimension");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdDimensionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDimension)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dimension_Product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Dimension");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IdDocumentType)
                    .HasName("PK_documentType");

                entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentName");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FileDesign>(entity =>
            {
                entity.HasKey(e => e.IdFileDesign)
                    .HasName("PK_idFileDesign");

                entity.Property(e => e.IdFileDesign).HasColumnName("idFileDesign");

                entity.Property(e => e.CodeFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codeFile");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DesignFimage).HasColumnName("designFImage");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.IdDesign).HasColumnName("idDesign");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDesignNavigation)
                    .WithMany(p => p.FileDesign)
                    .HasForeignKey(d => d.IdDesign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileDesign_Design");
            });

            modelBuilder.Entity<FileProduct>(entity =>
            {
                entity.HasKey(e => e.IdFileProduct)
                    .HasName("PK_idFileProduct");

                entity.Property(e => e.IdFileProduct).HasColumnName("idFileProduct");

                entity.Property(e => e.CodeFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codeFile");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.ProductImage).HasColumnName("productImage");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.FileProduct)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_FileProduct");
            });

            modelBuilder.Entity<PayMethod>(entity =>
            {
                entity.HasKey(e => e.IdPayMethod)
                    .HasName("PK_idPayMethod");

                entity.Property(e => e.IdPayMethod).HasColumnName("idPayMethod");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DescriptionMethod)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descriptionMethod");

                entity.Property(e => e.NameMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nameMethod");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK_idPerson");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BornDate)
                    .HasColumnType("date")
                    .HasColumnName("bornDate");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("documentNumber");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDocumentTypeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.IdDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_documentType_person");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK_IdProduct");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.BasePrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("basePrice");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductCategoryNavigation)
                    .WithMany(p => p.InverseIdProductCategoryNavigation)
                    .HasForeignKey(d => d.IdProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.IdProductCategory)
                    .HasName("PK_IdProductCategory");

                entity.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK_idSale");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.CodeSale)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codeSale");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdPayMethod).HasColumnName("idPayMethod");

                entity.Property(e => e.IdShoppingCart).HasColumnName("idShoppingCart");

                entity.Property(e => e.IdStatusSale).HasColumnName("idStatusSale");

                entity.HasOne(d => d.IdPayMethodNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.IdPayMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayMethod_Sale");

                entity.HasOne(d => d.IdShoppingCartNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.IdShoppingCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCart_Sale");

                entity.HasOne(d => d.IdStatusSaleNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.IdStatusSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusSale_Sale");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.IdShoppingCart)
                    .HasName("PK_idShoppingCart");

                entity.Property(e => e.IdShoppingCart).HasColumnName("idShoppingCart");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.ShoppingCartCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("shoppingCartCode");

                entity.Property(e => e.TotalMount)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("totalMount");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCart_User");
            });

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasKey(e => e.IdShoppingCartItem)
                    .HasName("PK_idShoppingCartItem");

                entity.Property(e => e.IdShoppingCartItem).HasColumnName("idShoppingCartItem");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.IdDesign).HasColumnName("idDesign");

                entity.Property(e => e.IdDimension).HasColumnName("idDimension");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdShoppingCart).HasColumnName("idShoppingCart");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("FK_Color_ShoppingCartItem");

                entity.HasOne(d => d.IdDesignNavigation)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.IdDesign)
                    .HasConstraintName("FK_Design_ShoppingCartItem");

                entity.HasOne(d => d.IdDimensionNavigation)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.IdDimension)
                    .HasConstraintName("FK_Dimension_ShoppingCartItem");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Product_ShoppingCartItem");

                entity.HasOne(d => d.IdShoppingCartNavigation)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.IdShoppingCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCartItem_ShoppingCart");
            });

            modelBuilder.Entity<StatusSale>(entity =>
            {
                entity.HasKey(e => e.IdStatusSale)
                    .HasName("PK_idStatusSale");

                entity.Property(e => e.IdStatusSale).HasColumnName("idStatusSale");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.NameStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nameStatus");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_idUser");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.LastPassword)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastPassword");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RecoveryPasswordCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("recoveryPasswordCode");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_User");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userType_User");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType)
                    .HasName("PK_idUserType");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

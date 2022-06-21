using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class TMDTContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private string dataSource;
        public TMDTContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TMDTContext(DbContextOptions<TMDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardRank> CardRanks { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<MembershipCard> MembershipCards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SerialProImage> SerialProImages { get; set; }
        public virtual DbSet<SerialProduct> SerialProducts { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ExAppConn"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CardRank>(entity =>
            {
                entity.HasKey(e => e.RankNo)
                    .HasName("pk_rank");

                entity.ToTable("CardRank");

                entity.Property(e => e.RankName).HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorNo)
                    .HasName("pk_color");

                entity.ToTable("Color");

                entity.Property(e => e.ColorNo).HasMaxLength(5);

                entity.Property(e => e.ColorName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNo)
                    .HasName("pk_customer");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerNo).HasMaxLength(55);

                entity.Property(e => e.CustomerAddress).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PassWord).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNo)
                    .HasName("pk_staff");

                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeNo).HasMaxLength(55);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmployeeName).HasMaxLength(100);

                entity.Property(e => e.PassWord).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.HasOne(d => d.RoleNoNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleNo)
                    .HasConstraintName("fk_role_employee");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackNo)
                    .HasName("pk_feedback");

                entity.ToTable("Feedback");

                entity.Property(e => e.Message).HasMaxLength(300);

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrderNo)
                    .HasConstraintName("fk_po_feedback");
            });

            modelBuilder.Entity<MembershipCard>(entity =>
            {
                entity.HasKey(e => e.CardNo)
                    .HasName("pk_membershipcard");

                entity.ToTable("MembershipCard");

                entity.Property(e => e.CardNo).HasMaxLength(55);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CustomerNo).HasMaxLength(55);

                entity.HasOne(d => d.CustomerNoNavigation)
                    .WithMany(p => p.MembershipCards)
                    .HasForeignKey(d => d.CustomerNo)
                    .HasConstraintName("fk_customer_membershipcard");

                entity.HasOne(d => d.RankNoNavigation)
                    .WithMany(p => p.MembershipCards)
                    .HasForeignKey(d => d.RankNo)
                    .HasConstraintName("fk_cardrank_membershipcard");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductNo)
                    .HasName("pk_product");

                entity.ToTable("Product");

                entity.Property(e => e.ProductNo).HasMaxLength(55);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductDescription).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.StyleNo).HasMaxLength(5);

                entity.Property(e => e.TypeNo).HasMaxLength(5);

                entity.HasOne(d => d.StyleNoNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StyleNo)
                    .HasConstraintName("fk_style_product");

                entity.HasOne(d => d.TypeNoNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeNo)
                    .HasConstraintName("fk_type_product");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.HasKey(e => new { e.ProductDescNo, e.ProductNo })
                    .HasName("pk_productdesc");

                entity.ToTable("ProductDescription");

                entity.Property(e => e.ProductDescNo).HasMaxLength(55);

                entity.Property(e => e.ProductNo).HasMaxLength(55);

                entity.Property(e => e.ProductDescImage).HasMaxLength(200);

                entity.Property(e => e.ProductDescription1).HasColumnName("ProductDescription");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.ProductDescriptions)
                    .HasForeignKey(d => d.ProductNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_productdesc");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.PromotionNo)
                    .HasName("pk_promotion");

                entity.ToTable("Promotion");

                entity.Property(e => e.PromotionNo).HasMaxLength(55);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PromotionName).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("pk_po");

                entity.ToTable("PurchaseOrder");

                entity.Property(e => e.CustomerNo).HasMaxLength(55);

                entity.Property(e => e.DeliveryAddress).HasMaxLength(200);

                entity.Property(e => e.EmployeeNo).HasMaxLength(55);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.VoucherNo).HasMaxLength(20);

                entity.HasOne(d => d.CustomerNoNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.CustomerNo)
                    .HasConstraintName("fk_customer_po");

                entity.HasOne(d => d.EmployeeNoNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.EmployeeNo)
                    .HasConstraintName("fk_staffinfo_po");

                entity.HasOne(d => d.VoucherNoNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.VoucherNo)
                    .HasConstraintName("fk_voucher_po");
            });

            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.SerialNo })
                    .HasName("pk_pol");

                entity.ToTable("PurchaseOrderLine");

                entity.Property(e => e.SerialNo).HasMaxLength(55);

                entity.Property(e => e.BuyPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_po_pol");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.SerialNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_serialpro_pol");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleNo)
                    .HasName("pk_role");

                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<SerialProImage>(entity =>
            {
                entity.HasKey(e => new { e.SerialNo, e.SerialImageNo })
                    .HasName("pk_serialProductImage");

                entity.ToTable("SerialProImage");

                entity.Property(e => e.SerialNo).HasMaxLength(55);

                entity.Property(e => e.SerialImageNo).HasMaxLength(55);

                entity.Property(e => e.ProductImageUrl).HasMaxLength(200);

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.SerialProImages)
                    .HasForeignKey(d => d.SerialNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_serialpro_serialproimg");
            });

            modelBuilder.Entity<SerialProduct>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("pk_serialProduct");

                entity.ToTable("SerialProduct");

                entity.Property(e => e.SerialNo).HasMaxLength(55);

                entity.Property(e => e.ColorNo).HasMaxLength(5);

                entity.Property(e => e.ProductDetailDescription).HasMaxLength(200);

                entity.Property(e => e.ProductDetailImage).HasMaxLength(200);

                entity.Property(e => e.ProductNo).HasMaxLength(55);

                entity.Property(e => e.PromotionNo).HasMaxLength(55);

                entity.Property(e => e.SizeNo).HasMaxLength(5);

                entity.HasOne(d => d.ColorNoNavigation)
                    .WithMany(p => p.SerialProducts)
                    .HasForeignKey(d => d.ColorNo)
                    .HasConstraintName("fk_color_serialpro");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.SerialProducts)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("fk_product_serialpro");

                entity.HasOne(d => d.PromotionNoNavigation)
                    .WithMany(p => p.SerialProducts)
                    .HasForeignKey(d => d.PromotionNo)
                    .HasConstraintName("fk_promotion_serialpro");

                entity.HasOne(d => d.SizeNoNavigation)
                    .WithMany(p => p.SerialProducts)
                    .HasForeignKey(d => d.SizeNo)
                    .HasConstraintName("fk_size_serialpro");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.SizeNo)
                    .HasName("pk_size");

                entity.ToTable("Size");

                entity.Property(e => e.SizeNo).HasMaxLength(5);

                entity.Property(e => e.SizeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.StyleNo)
                    .HasName("pk_style");

                entity.ToTable("Style");

                entity.Property(e => e.StyleNo).HasMaxLength(5);

                entity.Property(e => e.StyleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.TypeNo)
                    .HasName("pk_type");

                entity.ToTable("Type");

                entity.Property(e => e.TypeNo).HasMaxLength(5);

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.VoucherNo)
                    .HasName("pk_voucher");

                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherNo).HasMaxLength(20);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.VoucherName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

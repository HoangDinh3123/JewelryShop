using GoldenSmith.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Context
{
    public class JewelryDbContext:DbContext
    {
        public JewelryDbContext() { }
        public JewelryDbContext(DbContextOptions<JewelryDbContext> options) : base(options) { }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Jewelry> Jewelries{ get; set; }
        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Order> Orders{ get; set; }
        public virtual DbSet<OrderDetail> OrderDetails{ get; set; }
        public virtual DbSet<JewelryImage> JewelryImages{ get; set; }
        public virtual DbSet<JewelryReview> JewelryReviews{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(e => e.CategoryId);
                e.Property(e => e.CategoryId).IsRequired();
                e.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            });

            modelBuilder.Entity<Jewelry>(e =>
            {
                e.ToTable("Jewelry");
                e.HasKey(e => e.JewelryId);
                e.Property(e => e.JewelryId).IsRequired();
                e.Property(e => e.JewelryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.JewelryDescription)
                    .IsRequired()
                    .HasColumnType("nvarchar(MAX)");
                e.Property(e => e.JewelryWeight)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.JewelrySize)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.JewelryColor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.JewelryPrice)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.CategoryId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.UserId);
                e.Property(e => e.UserId).IsRequired();
                e.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnType("nvarchar(MAX)");
                e.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar");
                e.Property(e => e.UserPermission)
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(e => e.OrderId);
                e.Property(e => e.OrderId).IsRequired();
                e.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasColumnType("datetime");
                e.Property(e => e.OrderTotal)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.OrderStatus)
                    .IsRequired();
                e.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
                e.Property(e => e.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => e.OrderDetailId);
                e.Property(e => e.OrderDetailId).IsRequired();
                e.Property(e => e.Quantity)
                    .IsRequired();
                e.Property(e => e.OrderDetailPrice)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.OrderId)
                    .IsRequired();
                e.Property(e => e.JewelryId)
                    .IsRequired();
            });

            modelBuilder.Entity<JewelryReview>(e =>
            {
                e.ToTable("JewelryReview");
                e.HasKey(e => e.JewelryReviewId);
                e.Property(e => e.JewelryReviewId).IsRequired();
                e.Property(e => e.JewelryReviewRating)
                    .IsRequired()
                    .HasColumnType("float");
                e.Property(e => e.JewelryReviewComment)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar");
                e.Property(e => e.ReviewDate)
                    .IsRequired()
                    .HasColumnType("datetime");
                e.Property(e => e.JewelryId)
                    .IsRequired();
                e.Property(e => e.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<JewelryImage>(e =>
            {
                e.ToTable("JewelryImage");
                e.HasKey(e => e.JewelryImageId);
                e.Property(e => e.JewelryImageId).IsRequired();
                e.Property(e => e.JewelryImagePath)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)"); // Sử dụng nvarchar(max)
                e.Property(e => e.JewelryId)
                    .IsRequired();
            });
        }
    }
}

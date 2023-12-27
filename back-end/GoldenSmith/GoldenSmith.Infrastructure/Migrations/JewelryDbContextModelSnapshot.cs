﻿// <auto-generated />
using System;
using GoldenSmith.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldenSmith.Infrastructure.Migrations
{
    [DbContext(typeof(JewelryDbContext))]
    partial class JewelryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Jewelry", b =>
                {
                    b.Property<int>("JewelryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JewelryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("JewelryColor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("JewelryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("JewelryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<double>("JewelryPrice")
                        .HasColumnType("float");

                    b.Property<double>("JewelrySize")
                        .HasColumnType("float");

                    b.Property<double>("JewelryWeight")
                        .HasColumnType("float");

                    b.HasKey("JewelryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Jewelry", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.JewelryImage", b =>
                {
                    b.Property<int>("JewelryImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JewelryImageId"));

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<string>("JewelryImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("JewelryImageId");

                    b.HasIndex("JewelryId");

                    b.ToTable("JewelryImage", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.JewelryReview", b =>
                {
                    b.Property<int>("JewelryReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JewelryReviewId"));

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<string>("JewelryReviewComment")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.Property<double>("JewelryReviewRating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JewelryReviewId");

                    b.HasIndex("JewelryId");

                    b.HasIndex("UserId");

                    b.ToTable("JewelryReview", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<double>("OrderDetailPrice")
                        .HasColumnType("float");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("JewelryId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("UserPermission")
                        .HasColumnType("int");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Jewelry", b =>
                {
                    b.HasOne("GoldenSmith.Domain.Entities.Category", "Category")
                        .WithMany("Jewelries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.JewelryImage", b =>
                {
                    b.HasOne("GoldenSmith.Domain.Entities.Jewelry", "Jewelry")
                        .WithMany("JewelryImages")
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jewelry");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.JewelryReview", b =>
                {
                    b.HasOne("GoldenSmith.Domain.Entities.Jewelry", "Jewelry")
                        .WithMany("JewelryReviews")
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSmith.Domain.Entities.User", "User")
                        .WithMany("JewelryReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jewelry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Order", b =>
                {
                    b.HasOne("GoldenSmith.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("GoldenSmith.Domain.Entities.Jewelry", "Jewelry")
                        .WithMany("OrderDetails")
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSmith.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jewelry");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Category", b =>
                {
                    b.Navigation("Jewelries");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Jewelry", b =>
                {
                    b.Navigation("JewelryImages");

                    b.Navigation("JewelryReviews");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("GoldenSmith.Domain.Entities.User", b =>
                {
                    b.Navigation("JewelryReviews");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using EdChannel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EdChannel.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231028165315_update_1")]
    partial class update_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EdChannel.Models.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("EdChannel.Models.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Vendor")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EdChannel.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Province")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SeassionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("TokenId")
                        .HasMaxLength(100)
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EdChannel.Models.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EdChannel.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EdChannel.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("GrandTotal")
                        .HasColumnType("real");

                    b.Property<float>("ItemDiscount")
                        .HasColumnType("real");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Line1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Promo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Province")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Shipping")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.Property<float>("Tax")
                        .HasColumnType("real");

                    b.Property<string>("Token")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EdChannel.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EdChannel.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Price")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EdChannel.Models.ProductCategory", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("EdChannel.Models.ProductMeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMeta");
                });

            modelBuilder.Entity("EdChannel.Models.ProductReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductReview");
                });

            modelBuilder.Entity("EdChannel.Models.ProductTag", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("ProductId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("EdChannel.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EdChannel.Models.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EdChannel.Models.Cart", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EdChannel.Models.CartItem", b =>
                {
                    b.HasOne("EdChannel.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.Category", b =>
                {
                    b.HasOne("EdChannel.Models.Category", "CategoryParent")
                        .WithMany("CategoryChildren")
                        .HasForeignKey("ParentId");

                    b.Navigation("CategoryParent");
                });

            modelBuilder.Entity("EdChannel.Models.Order", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EdChannel.Models.OrderItem", b =>
                {
                    b.HasOne("EdChannel.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.Product", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EdChannel.Models.ProductCategory", b =>
                {
                    b.HasOne("EdChannel.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.ProductMeta", b =>
                {
                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany("ProductMetas")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.ProductReview", b =>
                {
                    b.HasOne("EdChannel.Models.ProductReview", "ParentReviews")
                        .WithMany("ChildReviews")
                        .HasForeignKey("ParentId");

                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentReviews");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.ProductTag", b =>
                {
                    b.HasOne("EdChannel.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.Tag", "Category")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdChannel.Models.Transaction", b =>
                {
                    b.HasOne("EdChannel.Models.Order", "Order")
                        .WithMany("Transactions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.ApplicationUser", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdChannel.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("EdChannel.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EdChannel.Models.ApplicationUser", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EdChannel.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("EdChannel.Models.Category", b =>
                {
                    b.Navigation("CategoryChildren");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("EdChannel.Models.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EdChannel.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");

                    b.Navigation("ProductMetas");

                    b.Navigation("ProductReviews");

                    b.Navigation("ProductTags");
                });

            modelBuilder.Entity("EdChannel.Models.ProductReview", b =>
                {
                    b.Navigation("ChildReviews");
                });

            modelBuilder.Entity("EdChannel.Models.Tag", b =>
                {
                    b.Navigation("ProductTags");
                });
#pragma warning restore 612, 618
        }
    }
}

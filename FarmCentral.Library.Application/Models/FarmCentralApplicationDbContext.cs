using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FarmCentral.Library.Application.Models
{
    public partial class FarmCentralApplicationDbContext : DbContext
    {
        public FarmCentralApplicationDbContext()
        {
        }

        public FarmCentralApplicationDbContext(DbContextOptions<FarmCentralApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Farmer> Farmers { get; set; } = null!;
        public virtual DbSet<FarmerProduct> FarmerProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.ToTable("farmer");

                entity.Property(e => e.FarmerId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("farmer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<FarmerProduct>(entity =>
            {
                entity.ToTable("farmer_product");

                entity.Property(e => e.FarmerProductId).HasColumnName("farmer_product_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("date")
                    .HasColumnName("date_added");

                entity.Property(e => e.FarmerId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("farmer_id");

                entity.Property(e => e.PricePerUnit)
                    .HasColumnType("money")
                    .HasColumnName("price_per_unit");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.FarmerProducts)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farmer_pr__farme__619B8048");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FarmerProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farmer_pr__produ__60A75C0F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("fk_product_type_id");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.Property(e => e.ProductTypeName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("product_type_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

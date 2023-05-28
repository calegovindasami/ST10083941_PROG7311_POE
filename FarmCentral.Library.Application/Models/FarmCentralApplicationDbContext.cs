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
        public virtual DbSet<OutgoingTransaction> OutgoingTransactions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=farm_central_application;Trusted_Connection=True;");
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
                    .HasConstraintName("FK__farmer_pr__farme__4E88ABD4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FarmerProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farmer_pr__produ__4D94879B");
            });

            modelBuilder.Entity<OutgoingTransaction>(entity =>
            {
                entity.ToTable("outgoing_transaction");

                entity.Property(e => e.OutgoingTransactionId).HasColumnName("outgoing_transaction_id");

                entity.Property(e => e.BuyerName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("buyer_name");

                entity.Property(e => e.FarmerId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("farmer_id");

                entity.Property(e => e.FarmerProductId).HasColumnName("farmer_product_id");

                entity.Property(e => e.SaleAmount)
                    .HasColumnType("money")
                    .HasColumnName("sale_amount");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("transaction_date");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.OutgoingTransactions)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__outgoing___farme__5165187F");

                entity.HasOne(d => d.FarmerProduct)
                    .WithMany(p => p.OutgoingTransactions)
                    .HasForeignKey(d => d.FarmerProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__outgoing___farme__52593CB8");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("product_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

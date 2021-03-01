using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QwiloMVCStore.Models
{
    public partial class QwiloStore : DbContext
    {
        public QwiloStore()
            : base("name=QwiloStore")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MasterCategory> MasterCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<MasterCategory>()
                .Property(e => e.CategoryID)
                .IsFixedLength();

            modelBuilder.Entity<MasterCategory>()
                .Property(e => e.CategoryName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductNumber)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Cart>()
                .Property(e => e.CartNo)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.ProductNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.ProductName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);
        }
    }
}

using FinancePal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinancePal.Data
{
    public class FinancePalDbContext: DbContext
    {
        public FinancePalDbContext(DbContextOptions<FinancePalDbContext> options)
           : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Transaction → User: No Cascade
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // مسیر حذف Cascade غیر فعال

            // Transaction → Category: Cascade
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Precision برای decimal
            modelBuilder.Entity<Asset>()
                .Property(a => a.Value)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);
        }

    }
}

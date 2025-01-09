using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Transaction> Transactions  { get; set; }
        public DbSet<User> Users { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Offers with cascade delete
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Requests with cascade delete
            modelBuilder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Offer -> Request with restrict delete
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Offer)
                .WithMany(o => o.Requests)
                .HasForeignKey(r => r.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction -> Offer with restrict delete
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Offer)
                .WithMany(o => o.Transactions)
                .HasForeignKey(t => t.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction -> Request with restrict delete
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Request)
                .WithMany(r => r.Transactions)
                .HasForeignKey(t => t.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Additional precision settings as needed
            modelBuilder.Entity<Offer>()
                .Property(o => o.Price)
                .HasPrecision(18, 2); // Adjust precision and scale as required              

            modelBuilder.Entity<Offer>()
                .Property(o => o.Quantity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Request>()
                .Property(r => r.Quantity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Quantity)
                .HasPrecision(18, 2);
        }
    }
}

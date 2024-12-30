using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Produce> Produces { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Transaction> Transactions  { get; set; }
        public DbSet<User> Users { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            // Configure the relationship between Transactions and Offers
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Offer)
                .WithMany() // Assuming there is no navigation property on Offer
                .HasForeignKey(t => t.OfferId)
                .OnDelete(DeleteBehavior.NoAction); // You can change this to NoAction or Restrict if needed

            // Configure the relationship between Transactions and Requests
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Request)
                .WithMany() // Assuming there is no navigation property on Request
                .HasForeignKey(t => t.RequestId)
                .OnDelete(DeleteBehavior.NoAction); // To prevent cascade conflict
        }
    }
}

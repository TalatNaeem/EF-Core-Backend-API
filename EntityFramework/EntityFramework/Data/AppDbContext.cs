using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType() { Id = 1, Currency = "INR", Description = "Indian Currency" },
                new CurrencyType() { Id = 2, Currency = "PKR", Description = "Pakistani CUrrency" },
                new CurrencyType() { Id = 3, Currency = "DLR", Description = "USA Currency" },
                new CurrencyType() { Id = 4, Currency = "Euro", Description = "Europian Currency" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { Id = 2, Title = "Urdu", Description = "Urdu" },
                new Language() { Id = 3, Title = "English", Description = "English" },
                new Language() { Id = 4, Title = "Punjabi", Description = "Punjabi" }
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
    }
}

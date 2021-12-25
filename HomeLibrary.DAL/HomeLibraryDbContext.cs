using HomeLibrary.DAL.Configuration;
using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeLibrary.DAL
{
    public class HomeLibraryDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public HomeLibraryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}

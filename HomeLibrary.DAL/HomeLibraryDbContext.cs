using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL
{
    public class HomeLibraryDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public HomeLibraryDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity => { entity.HasIndex(e => e.Url).IsUnique(); });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "F1", MiddleName = "M1", LastName = "L1" },
                new Author { Id = 2, FirstName = "F2", MiddleName = "", LastName = "L2" },
                new Author { Id = 3, FirstName = "F3", MiddleName = "M3", LastName = "L3" }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Title1" },
                new Book { Id = 2, Title = "Title2" },
                new Book { Id = 3, Title = "Title3" }
                );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "image1", BookId = 1 },
                new Image { Id = 2, Url = "image2", BookId = 2 },
                new Image { Id = 3, Url = "image3", BookId = 3 },
                new Image { Id = 4, Url = "image4", BookId = 1 },
                new Image { Id = 5, Url = "image5", BookId = 2 }
                );
            modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books)
                .UsingEntity(j => j.HasData(
                    new { AuthorsId = 1, BooksId = 1 },
                    new { AuthorsId = 2, BooksId = 2 },
                    new { AuthorsId = 2, BooksId = 3 },
                    new { AuthorsId = 3, BooksId = 3 }
                    ));

            base.OnModelCreating(modelBuilder);
        }
    }
}

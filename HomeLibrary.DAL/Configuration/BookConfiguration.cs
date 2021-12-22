using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeLibrary.DAL.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Title).IsRequired();
            builder
                .HasMany<Image>(book => book.Images)
                .WithOne(book => book.Book)
                .HasForeignKey(author => author.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Book { Id = 1, Title = "Title1" },
                new Book { Id = 2, Title = "Title2" },
                new Book { Id = 3, Title = "Title3" }
                );

            builder
                .HasMany(book => book.Authors)
                .WithMany(author => author.Books)
                .UsingEntity(t => t.HasData(
                    new { AuthorsId = 1, BooksId = 1 },
                    new { AuthorsId = 2, BooksId = 2 },
                    new { AuthorsId = 2, BooksId = 3 },
                    new { AuthorsId = 3, BooksId = 3 }
                    ));
        }
    }
}

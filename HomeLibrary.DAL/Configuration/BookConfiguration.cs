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
            builder.Property(book => book.PublishDate).IsRequired();
            builder.Property(book => book.NumberOfPages).IsRequired();
            builder.HasIndex(book => book.ISBN).IsUnique();
            builder
                .HasMany<Image>(book => book.Images)
                .WithOne(book => book.Book)
                .HasForeignKey(author => author.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Book { Id = 1, Title = "Title1", ISBN = "9784353434", PublishDate = 2013, NumberOfPages = 10 },
                new Book { Id = 2, Title = "Title2", ISBN = "9784300434", PublishDate = 2014, NumberOfPages = 20 },
                new Book { Id = 3, Title = "Title3", ISBN = "9784340434", PublishDate = 2015, NumberOfPages = 30 }
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
            builder
                .HasMany(book => book.Tags)
                .WithMany(tag => tag.Books)
                .UsingEntity(t => t.HasData(
                    new { TagsId = 1, BooksId = 1 },
                    new { TagsId = 3, BooksId = 1 },
                    new { TagsId = 2, BooksId = 2 }
                    ));
        }
    }
}

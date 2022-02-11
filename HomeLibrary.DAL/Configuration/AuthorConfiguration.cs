using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.Property(author => author.FullName).IsRequired();
            builder.HasIndex(author => author.FullName).IsUnique();

            builder.HasData(
                new Author { Id = 1, FullName = "F1 L1" },
                new Author { Id = 2, FullName = "F2 L2" },
                new Author { Id = 3, FullName = "F3 L3" }
                );

        }
    }
}

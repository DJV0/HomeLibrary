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
            builder.Property(author => author.FirstName).IsRequired();
            builder.Property(author => author.LastName).IsRequired();

            builder.HasData(
                new Author { Id = 1, FirstName = "F1", LastName = "L1" },
                new Author { Id = 2, FirstName = "F2", LastName = "L2" },
                new Author { Id = 3, FirstName = "F3", LastName = "L3" }
                );

        }
    }
}

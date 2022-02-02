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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(tag => tag.Name).IsRequired();
            builder.HasIndex(tag => tag.Name).IsUnique();

            builder.HasData(
                new Tag { Id = 1, Name = "книга 2021" },
                new Tag { Id = 2, Name = "музыка" },
                new Tag { Id = 3, Name = "наука" }
                );
        }
    }
}

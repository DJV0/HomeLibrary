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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);
            builder.Property(image => image.Uri).IsRequired();
            builder.HasIndex(image => image.Uri).IsUnique();

            builder.HasData(
                new Image { Id = 1, Uri = "image1", BookId = 1 },
                new Image { Id = 2, Uri = "image2", BookId = 2 },
                new Image { Id = 3, Uri = "image3", BookId = 3 },
                new Image { Id = 4, Uri = "image4", BookId = 1 },
                new Image { Id = 5, Uri = "image5", BookId = 2 }
                );
        }
    }
}

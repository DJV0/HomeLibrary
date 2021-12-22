﻿// <auto-generated />
using HomeLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeLibrary.DAL.Migrations
{
    [DbContext(typeof(HomeLibraryDbContext))]
    [Migration("20211222104141_AddBookTags")]
    partial class AddBookTags
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");

                    b.HasData(
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 1
                        },
                        new
                        {
                            AuthorsId = 2,
                            BooksId = 2
                        },
                        new
                        {
                            AuthorsId = 2,
                            BooksId = 3
                        },
                        new
                        {
                            AuthorsId = 3,
                            BooksId = 3
                        });
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<string>("TagsName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BooksId", "TagsName");

                    b.HasIndex("TagsName");

                    b.ToTable("BookTag");

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            TagsName = "книга 2021"
                        },
                        new
                        {
                            BooksId = 1,
                            TagsName = "наука"
                        },
                        new
                        {
                            BooksId = 2,
                            TagsName = "музыка"
                        });
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "F1",
                            LastName = "L1",
                            MiddleName = "M1"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "F2",
                            LastName = "L2",
                            MiddleName = ""
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "F3",
                            LastName = "L3",
                            MiddleName = "M3"
                        });
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Url = "image1"
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Url = "image2"
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Url = "image3"
                        },
                        new
                        {
                            Id = 4,
                            BookId = 1,
                            Url = "image4"
                        },
                        new
                        {
                            Id = 5,
                            BookId = 2,
                            Url = "image5"
                        });
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Name = "книга 2021"
                        },
                        new
                        {
                            Name = "музыка"
                        },
                        new
                        {
                            Name = "наука"
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("HomeLibrary.DAL.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeLibrary.DAL.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.HasOne("HomeLibrary.DAL.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeLibrary.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Image", b =>
                {
                    b.HasOne("HomeLibrary.DAL.Entities.Book", "Book")
                        .WithMany("Images")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("HomeLibrary.DAL.Entities.Book", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

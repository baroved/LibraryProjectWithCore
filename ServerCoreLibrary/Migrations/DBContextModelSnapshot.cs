﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerCoreLibrary.DAL;

namespace ServerCoreLibrary.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shared.Model.AbstractItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CopiesInStock");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImgUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<DateTime>("PrintDate");

                    b.Property<int>("PublisherId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("AbstractItem");

                    b.HasDiscriminator<string>("Type").HasValue("AbstractItem");
                });

            modelBuilder.Entity("Shared.Model.BookGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("GenreId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            GenreId = 4
                        });
                });

            modelBuilder.Entity("Shared.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mr.Oved"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mr.Hadar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mr.Itay"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mr.Mosha"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ms.Daniel"
                        });
                });

            modelBuilder.Entity("Shared.Model.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Edition");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Daily"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Weekly"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Holiday"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Yearly"
                        });
                });

            modelBuilder.Entity("Shared.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Children"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Comedy"
                        });
                });

            modelBuilder.Entity("Shared.Model.GenreDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId");

                    b.Property<int>("Percent");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("GenresDiscount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            Percent = 40
                        });
                });

            modelBuilder.Entity("Shared.Model.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<int?>("GenreDiscountId");

                    b.Property<int?>("PublisherDiscountId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int?>("WriterDiscountId");

                    b.HasKey("Id");

                    b.HasIndex("GenreDiscountId");

                    b.HasIndex("PublisherDiscountId");

                    b.HasIndex("WriterDiscountId");

                    b.ToTable("Promotions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateEnd = new DateTime(2020, 2, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(8667),
                            DateStart = new DateTime(2020, 1, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(8208),
                            PublisherDiscountId = 1,
                            Type = "Publisher"
                        },
                        new
                        {
                            Id = 2,
                            DateEnd = new DateTime(2020, 2, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(9884),
                            DateStart = new DateTime(2020, 1, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(9872),
                            Type = "Writer",
                            WriterDiscountId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateEnd = new DateTime(2020, 2, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(662),
                            DateStart = new DateTime(2020, 1, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(654),
                            GenreDiscountId = 1,
                            Type = "Genre"
                        });
                });

            modelBuilder.Entity("Shared.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Keshet"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maariv"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hebrew"
                        });
                });

            modelBuilder.Entity("Shared.Model.PublisherDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Percent");

                    b.Property<int>("PublisherId");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("PublishersDiscount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Percent = 20,
                            PublisherId = 1
                        });
                });

            modelBuilder.Entity("Shared.Model.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("FinalPrice");

                    b.Property<int>("ItemId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Shared.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "baroved6@gmail.com",
                            IsAdmin = true,
                            Password = "12345",
                            UserName = "baroved"
                        },
                        new
                        {
                            Id = 2,
                            Email = "baroved6@walla.com",
                            IsAdmin = false,
                            Password = "12345",
                            UserName = "bar"
                        });
                });

            modelBuilder.Entity("Shared.Model.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Writers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Joseph Elijah"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jacob Eliav"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dan Almagor"
                        });
                });

            modelBuilder.Entity("Shared.Model.WriterDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Percent");

                    b.Property<int>("WriterId");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("WritersDiscount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Percent = 30,
                            WriterId = 1
                        });
                });

            modelBuilder.Entity("Shared.Model.Book", b =>
                {
                    b.HasBaseType("Shared.Model.AbstractItem");

                    b.Property<string>("Isbn")
                        .IsRequired();

                    b.Property<int>("WriterId");

                    b.HasIndex("WriterId");

                    b.HasDiscriminator().HasValue("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CopiesInStock = 10,
                            Description = "dfgdfgdfgdfgdg",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                            Name = "Harry Potter",
                            Price = 49.899999999999999,
                            PrintDate = new DateTime(2020, 1, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(7705),
                            PublisherId = 1,
                            Isbn = "4a0fbf6f-0bf6-4f9d-9478-629941033254",
                            WriterId = 1
                        });
                });

            modelBuilder.Entity("Shared.Model.Journal", b =>
                {
                    b.HasBaseType("Shared.Model.AbstractItem");

                    b.Property<int>("EditionId");

                    b.HasIndex("EditionId");

                    b.HasDiscriminator().HasValue("Journal");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CopiesInStock = 10,
                            Description = "dfgdfgdfgdfgdg",
                            ImgUrl = "https://www.jpostlite.co.il/wp-content/uploads/2013/07/1-2.jpg",
                            Name = "Zone",
                            Price = 30.899999999999999,
                            PrintDate = new DateTime(2020, 1, 21, 16, 29, 7, 365, DateTimeKind.Local).AddTicks(2053),
                            PublisherId = 2,
                            EditionId = 1
                        });
                });

            modelBuilder.Entity("Shared.Model.AbstractItem", b =>
                {
                    b.HasOne("Shared.Model.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.BookGenre", b =>
                {
                    b.HasOne("Shared.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Model.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.GenreDiscount", b =>
                {
                    b.HasOne("Shared.Model.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.Promotion", b =>
                {
                    b.HasOne("Shared.Model.GenreDiscount", "GenreDiscount")
                        .WithMany()
                        .HasForeignKey("GenreDiscountId");

                    b.HasOne("Shared.Model.PublisherDiscount", "PublisherDiscount")
                        .WithMany()
                        .HasForeignKey("PublisherDiscountId");

                    b.HasOne("Shared.Model.WriterDiscount", "WriterDiscount")
                        .WithMany()
                        .HasForeignKey("WriterDiscountId");
                });

            modelBuilder.Entity("Shared.Model.PublisherDiscount", b =>
                {
                    b.HasOne("Shared.Model.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.Sale", b =>
                {
                    b.HasOne("Shared.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Model.AbstractItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shared.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.WriterDiscount", b =>
                {
                    b.HasOne("Shared.Model.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.Book", b =>
                {
                    b.HasOne("Shared.Model.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shared.Model.Journal", b =>
                {
                    b.HasOne("Shared.Model.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

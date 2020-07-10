using Microsoft.EntityFrameworkCore;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.DAL
{
    public class DBContext : DbContext
    {
        #region Constructor
        public DBContext(DbContextOptions options) : base(options) { }
        #endregion

        #region Methods
        //seed database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Publisher Keshet = new Publisher
            {
                Id = 1,
                Name = "Keshet"
            };
            Publisher Maariv = new Publisher
            {
                Id = 2,
                Name = "Maariv"
            };
            Publisher Hebrew = new Publisher
            {
                Id = 3,
                Name = "Hebrew"
            };

            modelBuilder.Entity<Publisher>().HasData(Keshet, Maariv, Hebrew);

            WriterDiscount writerDiscount = new WriterDiscount
            {
                Id = 1,
                WriterId = 1,
                Percent = 30
            };

            modelBuilder.Entity<WriterDiscount>().HasData(writerDiscount);

            GenreDiscount genreDiscount = new GenreDiscount
            {
                Id = 1,
                GenreId = 1,
                Percent = 40
            };
            modelBuilder.Entity<GenreDiscount>().HasData(genreDiscount);

            PublisherDiscount NewDiscount = new PublisherDiscount
            {
                Id = 1,
                PublisherId = Keshet.Id,
                Percent = 20
            };
            modelBuilder.Entity<PublisherDiscount>().HasData(NewDiscount);


            Promotion NewPromotion = new Promotion
            {
                Id = 1,
                PublisherDiscountId = NewDiscount.Id,
                WriterDiscountId = null,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddMonths(1),
                Type="Publisher"
            };

            Promotion secondPromotion = new Promotion
            {
                Id = 2,
                PublisherDiscountId = null,
                WriterDiscountId = writerDiscount.Id,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddMonths(1),
                Type="Writer"
            };
            Promotion thirdPromotion = new Promotion
            {
                Id = 3,
                PublisherDiscountId = null,
                WriterDiscountId = null,
                GenreDiscountId = genreDiscount.Id,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddMonths(1),
                Type="Genre"
            };

            modelBuilder.Entity<Promotion>().HasData(NewPromotion, secondPromotion, thirdPromotion);


            Writer Writer1 = new Writer
            {
                Id = 1,
                Name = "Joseph Elijah"
            };

            Writer Writer2 = new Writer
            {
                Id = 2,
                Name = "Jacob Eliav"
            };

            Writer Writer3 = new Writer
            {
                Id = 3,
                Name = "Dan Almagor"
            };

            modelBuilder.Entity<Writer>().HasData(Writer1, Writer2, Writer3);




            Edition Daily = new Edition
            {
                Id = 1,
                Name = "Daily"
            };

            Edition Weekly = new Edition
            {
                Id = 2,
                Name = "Weekly"
            };

            Edition Holiday = new Edition
            {
                Id = 3,
                Name = "Holiday"
            };

            Edition Yearly = new Edition
            {
                Id = 4,
                Name = "Yearly"
            };
            modelBuilder.Entity<Edition>().HasData(Daily, Weekly, Holiday, Yearly);



            Genre Drama = new Genre
            {
                Id = 1,
                Type = "Drama"
            };

            Genre Horror = new Genre
            {
                Id = 2,
                Type = "Horror"
            };

            Genre Children = new Genre
            {
                Id = 3,
                Type = "Children"
            };

            Genre Comedy = new Genre
            {
                Id = 4,
                Type = "Comedy"
            };

            modelBuilder.Entity<Genre>().HasData(Drama, Horror, Children, Comedy);
            Book newBook = new Book
            {
                Id = 1,
                Name = "Harry Potter",
                PrintDate = DateTime.Now,
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                Isbn = Guid.NewGuid().ToString(),
                WriterId = Writer1.Id,
                PublisherId = Keshet.Id

            };

            Journal newJournal = new Journal
            {
                Id = 2,
                Name = "Zone",
                PrintDate = DateTime.Now,
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 30.9,
                ImgUrl = "https://www.jpostlite.co.il/wp-content/uploads/2013/07/1-2.jpg",
                EditionId = Daily.Id,
                PublisherId = Maariv.Id

            };

            modelBuilder.Entity<Book>().HasData(newBook);
            modelBuilder.Entity<Journal>().HasData(newJournal);


            BookGenre FirstBookGenra = new BookGenre
            {
                Id = 1,
                BookId = newBook.Id,
                GenreId = Drama.Id
            };
            BookGenre SecondBookGenra = new BookGenre
            {
                Id = 2,
                BookId = newBook.Id,
                GenreId = Comedy.Id
            };
            modelBuilder.Entity<BookGenre>().HasData(FirstBookGenra, SecondBookGenra);

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 1,
                  UserName = "baroved",
                  Password = "12345",
                  Email = "baroved6@gmail.com",
                  IsAdmin = true
              },
              new User
              {
                  Id = 2,
                  UserName = "bar",
                  Password = "12345",
                  Email = "baroved6@walla.com",
                  IsAdmin = false
              }
            );



            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   Id = 1,
                   Name = "Mr.Oved"

               },
                new Customer
                {
                    Id = 2,
                    Name = "Mr.Hadar"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Mr.Itay"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Mr.Mosha"
                },
                new Customer
                {
                    Id = 5,
                    Name = "Ms.Daniel"
                }
            );

            modelBuilder.Entity<AbstractItem>().HasDiscriminator(ai => ai.Type);
        }
        #endregion

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<AbstractItem> AbstractItem { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Edition> Edition { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<PublisherDiscount> PublishersDiscount { get; set; }
        public DbSet<WriterDiscount> WritersDiscount { get; set; }
        public DbSet<GenreDiscount> GenresDiscount { get; set; }
        #endregion
    }
}

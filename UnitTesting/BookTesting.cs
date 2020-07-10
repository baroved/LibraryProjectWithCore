using BusinessLogic.InputValidation;
using Shared.Model;
using System;
using Xunit;

namespace UnitTesting
{
    public class BookTesting
    {
        #region MethodsTesting
        [Fact]
        public void AddBook()
        {
            Book newBook = new Book
            {
                Isbn="1234567",
                Name = "Harry Potter",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                WriterId = 1,
                PublisherId = 1

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidForAddBook(newBook);
            Assert.True(ok);
        }


        [Fact]
        public void AddBookError()
        {
            Book newBook = new Book
            {
                Name = "Harry Potter",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                WriterId = 1

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidForAddBook(newBook);
            Assert.False(ok);
        }

        [Fact]
        public void UpdateBook()
        {
            Book Book = new Book
            {
                Name = "sfgfdg",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidUpdatedItem(Book);
            Assert.True(ok);
        }

        [Fact]
        public void UpdateBookError()
        {
            Book Book = new Book
            {
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidUpdatedItem(Book);
            Assert.False(ok);
        }
        #endregion
    }
}

using BusinessLogic.InputValidation;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting
{
    public class JournalTesting
    {
        #region MethodsTesting
        [Fact]
        public void AddJournal()
        {
            Journal newJournal = new Journal
            {
                Name = "Harry Potter",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                EditionId = 1,
                PublisherId = 1

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidForAddJournal(newJournal);
            Assert.True(ok);
        }


        [Fact]
        public void AddJournalError()
        {
            Journal newJournal = new Journal
            {
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                EditionId = 1,
                PublisherId = 1

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidForAddJournal(newJournal);
            Assert.False(ok);
        }

        [Fact]
        public void UpdateJournal()
        {
            Journal journal = new Journal
            {
                Id = 1,
                Name = "sfgfdg",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidUpdatedItem(journal);
            Assert.True(ok);
        }




        [Fact]
        public void UpdateJournalError()
        {
            Journal journal = new Journal
            {
                Id = 1,
                Name = "sfgfdg",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",

            };

            ValidationInputs test = new ValidationInputs();
            bool ok = test.ValidUpdatedItem(journal);
            Assert.False(ok);
        }
        #endregion
    }
}

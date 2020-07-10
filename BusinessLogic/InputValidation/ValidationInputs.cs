using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.InputValidation
{
    public class ValidationInputs
    {
        #region Methods
        //check validation for add book
        public bool ValidForAddBook(Book newBook)
        {
            if (string.IsNullOrEmpty(newBook.Name) || string.IsNullOrEmpty(newBook.Description) ||
                string.IsNullOrEmpty(newBook.ImgUrl) || newBook.CopiesInStock <= 0 || newBook.Price <= 0 || newBook.PrintDate == null ||
                newBook.PublisherId <= 0 || newBook.WriterId <= 0 || string.IsNullOrEmpty(newBook.Isbn))
                return false;
            return true;
        }


        //check validation for add journal
        public bool ValidForAddJournal(Journal newJournal)
        {
            if (string.IsNullOrEmpty(newJournal.Name) || string.IsNullOrEmpty(newJournal.Description) ||
                string.IsNullOrEmpty(newJournal.ImgUrl) || newJournal.CopiesInStock <= 0 || newJournal.Price <= 0 || newJournal.PrintDate == null ||
                newJournal.PublisherId <= 0 || newJournal.EditionId <= 0)
                return false;
            return true;
        }

        //check validation for update item
        public bool ValidUpdatedItem(AbstractItem item)
        {
            if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Description) ||
                string.IsNullOrEmpty(item.ImgUrl) || item.CopiesInStock <= 0 || item.Price <= 0 || item.PrintDate == null)
                return false;
            return true;
        }

        //check validation for selling
        public bool ValidForBuying(Sale historySale)
        {
            if (historySale.CustomerId <= 0 || historySale.UserId <= 0
                || historySale.ItemId <= 0 || historySale.Date == null)
                return false;
            return true;
        }
        #endregion
    }
}

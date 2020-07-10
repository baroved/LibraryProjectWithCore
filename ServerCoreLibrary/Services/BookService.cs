using BusinessLogic.InputValidation;
using ServerCoreLibrary.API;
using ServerCoreLibrary.Repository.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Services
{
    public class BookService : IBookService
    {
        #region Properties
        private readonly IBookRepository _bookRepository;
        private readonly ValidationInputs _validation;
        #endregion

        #region Constructor
        public BookService(IBookRepository bookRepository, ValidationInputs validation)
        {
            _bookRepository = bookRepository;
            _validation = validation;
        }
        #endregion

        #region Methods
        public async Task<bool> AddBookAsync(Book newBook)
        {
            bool ok = _validation.ValidForAddBook(newBook);
            if (ok)
                return await _bookRepository.AddBookAsync(newBook);
            return false;

        }

        public async Task<Book> GetBookById(int bookId)
        {
            return await _bookRepository.GetBookById(bookId);
        }

        public async Task<bool> UpdateBookAsync(Book item)
        {
            bool ok = _validation.ValidUpdatedItem(item);
            if (ok)
                return await _bookRepository.UpdateBookAsync(item);
            return false;
        }
        #endregion
    }
}

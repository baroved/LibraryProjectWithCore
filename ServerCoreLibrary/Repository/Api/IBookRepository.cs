using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCoreLibrary.Repository.Api
{
    public interface IBookRepository
    {
        #region Methods
        Task<bool> AddBookAsync(Book newBook);
        Task<bool> UpdateBookAsync(Book item);
        Task<Book> GetBookById(int bookId);
        #endregion
    }
}

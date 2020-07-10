using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Api
{
    public interface IHttpBook
    {
        #region Methods
        Task<bool> AddBookAsync(Book newBook);
        Task<bool> UpdateBookAsync(Book item);
        Task<Book> GetBookById(int bookId);
        #endregion

    }
}

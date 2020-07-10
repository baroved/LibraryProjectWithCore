using ClientLib.Api;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpBook:IHttpBook
    {
        #region Properties
        private readonly IHttpService _httpService;
        #endregion

        #region Constructor
        public HttpBook(IHttpService httpService)
        {
            _httpService = httpService;
        }
        #endregion

        #region Methods
        //send url and object to postAsync for add book
        public async Task<bool> AddBookAsync(Book newBook)
        {
            return await _httpService.PostAsync<Book, bool>("Book/AddBook", newBook);
        }

        //send url with bookid to getAsync for get Book 
        public async Task<Book> GetBookById(int bookId)
        {
            return await _httpService.GetAsync<Book>($"Book/GetBook/{bookId}");
        }
        
        //send url and book to postAsync for update book
        public async Task<bool> UpdateBookAsync(Book item)
        {
            return await _httpService.PostAsync<Book, bool>("Book/UpdateBook", item);
        }
        #endregion
    }
}

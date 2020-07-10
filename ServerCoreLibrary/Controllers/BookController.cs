using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;
using Shared.Model;

namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("AddBook")]
        public async Task<bool> AddBook(Book newBook)
        {
            if (ModelState.IsValid)
                return await _bookService.AddBookAsync(newBook);
            return false;
        }

        [HttpPost("UpdateBook")]
        public async Task<bool> UpdateBook([FromBody]Book item)
        {
            if (ModelState.IsValid)
                return await _bookService.UpdateBookAsync(item);
            return false;
        }

        [HttpGet("GetBook/{bookId}")]
        public async Task<Book> GetBookById(int bookId)
        {
            return await _bookService.GetBookById(bookId);
        }


    }
}
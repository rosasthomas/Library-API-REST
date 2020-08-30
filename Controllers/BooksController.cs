using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _context;
        private IBooksService _booksService;
        public BooksController(LibraryDbContext context, IBooksService booksService)
        {
            this._context = context;
            this._booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = this._booksService.GetAll();

            if (bookList.Count() > 0)
                return Ok(bookList);
            else
                return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var target = this._booksService.GetBookById(id);

            if (target != null)
                return Ok(target);
            else
                return NotFound();
        }

        [HttpGet("{title}")]
        public IActionResult GetBookByTitle(string title)
        {
            var bookList = this._booksService.GetBookByTitle(title);

            if (bookList.Count() > 0)
                return Ok(bookList);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (book == null || !this.ModelState.IsValid || !this._booksService.AddBook(book))
                return BadRequest();
            else
                return Created($"books/{book.idBook}", book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (this._booksService.UpdateBook(id, book))
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            if (this._booksService.DeleteBook(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}

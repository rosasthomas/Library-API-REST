using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();
        Book GetBookById(int id);
        IEnumerable<Book> GetBookByTitle(string title);
        bool AddBook(Book book);
        bool UpdateBook(int id, Book book);
        bool DeleteBook(int id);
    }

    public class BooksService : IBooksService
    {
        private LibraryDbContext _context;
        public BooksService(LibraryDbContext context)
        {
            this._context = context;
        }
        public bool AddBook(Book book)
        {
            this._context.Books.Add(book);
            return this._context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteBook(int id)
        {
            var book = this._context.Books.FirstOrDefault(ct => ct.idBook == id);

            if (book != null)
            {
                this._context.Books.Remove(book);
                return this._context.SaveChanges() > 0 ? true : false;
            }
            else
                return false;
        }

        public IEnumerable<Book> GetAll()
        {
            return this._context.Books.Include(b => b.Authors).ToList();
        }

        public Book GetBookById(int id)
        {
            return this._context.Books.Include(b => b.Authors).FirstOrDefault(b => b.idBook == id);
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return this._context.Books.Where(b => b.title == title).ToList();
        }

        public bool UpdateBook(int id, Book book)
        {
            var target = this._context.Books.FirstOrDefault(b => b.idBook == id);

            if (target != null)
            {
                target.description = book.description;
                target.genre = book.genre;
                target.idAuthor = book.idAuthor;
                target.publisher = book.publisher;
                target.publisher = book.section;
                target.title = book.title;
                target.year = book.year;

                this._context.Update(target);

                return this._context.SaveChanges() > 0 ? true : false;
            }
            else
                return false;
        }
    }
}

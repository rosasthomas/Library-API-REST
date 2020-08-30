using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthorsService
    {
        IEnumerable<Author> GetAll();
        Author GetAuthorById(int id);
        IEnumerable<Author> GetAuthorByName(string name);
        bool AddAuthor(Author author);
        bool UpdateAuthor(int id, Author author);
        bool DeleteAuthor(int id);
    }
    public class AuthorsService : IAuthorsService
    {
        private LibraryDbContext _context;
        public AuthorsService(LibraryDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Author> GetAll()
        {
            return this._context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return this._context.Authors.SingleOrDefault(ct => ct.idAuthor == id);
        }

        public IEnumerable<Author> GetAuthorByName(string name)
        {
            return this._context.Authors.Where(ct => ct.name == name).ToList();
        }

        public bool AddAuthor(Author author)
        {
            this._context.Authors.Add(author);
            return this._context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateAuthor(int id, Author author)
        {
            var target = this._context.Authors.FirstOrDefault(ct => ct.idAuthor == id);

            if (target == null)
            {
                return false;
            }
            else
            {
                target.name = author.name;
                target.lastName = author.lastName;
                target.email = author.email;

                this._context.Authors.Update(target);
                
                return this._context.SaveChanges() > 0 ? true : false;
            }
        }

        public bool DeleteAuthor(int id)
        {
            var target = this._context.Authors.FirstOrDefault(ct => ct.idAuthor == id);

            if (target == null)
            {
                return false;
            }
            else
            {
                this._context.Authors.Remove(target);
                this._context.SaveChanges();
                return this._context.SaveChanges() > 0 ? true : false;
            }
        }
    }
}

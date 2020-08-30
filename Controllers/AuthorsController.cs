using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("authors")]
    public class AuthorsController : Controller
    {
        private readonly LibraryDbContext _context;
        private IAuthorsService _authorsService;
        public AuthorsController(LibraryDbContext context, IAuthorsService authorsService)
        {
            _context = context;
            _authorsService = authorsService;
        }   

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorsList = this._authorsService.GetAll();

            if (authorsList.Count() != 0) {
                return Ok(authorsList);
            }
            else
            {
                return NotFound();
            }
        }

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = this._authorsService.GetAuthorById(id);

            if(author != null)
            {
                return Ok(author);
            }
            else
            {
                return NotFound();
            }
        }

        //Search by name
        [HttpGet("{name}")]
        public IActionResult GetAuthorByName(string name)
        {
            var authorList = this._authorsService.GetAuthorByName(name);

            if(authorList == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(authorList);
            }
        }

        //Add Author
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!this.ModelState.IsValid || !this._authorsService.AddAuthor(author))
            {
                return BadRequest();
            }
            else
            {
                return Created($"authors/{author.idAuthor}", author);
            }
        }

        //Update Authors
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (this._authorsService.UpdateAuthor(id, author))
                return Ok();
            else
                return BadRequest();
        }

        //Delete Author
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if (this._authorsService.DeleteAuthor(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}

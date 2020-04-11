using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/authors/{authorId}/books")]
    public class BookController : Controller
    {
        public BookController(IBookReponsitory bookReponsitory,IAuthorResponsitory authorResponsitory)
        {
            BookReponsitory = bookReponsitory;
            AuthorResponsitory = authorResponsitory;
        }

        public IAuthorResponsitory AuthorResponsitory { get; }
        public IBookReponsitory BookReponsitory { get; }


        [HttpGet]
        public ActionResult<List<BookDto>> GetBooks(Guid authorId)
        {
            if (!AuthorResponsitory.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            return BookReponsitory.GetBooksForAuthor(authorId).ToList();
        }

        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBook(Guid authorId,Guid bookId)
        {
            if (!AuthorResponsitory.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var targetBook= BookReponsitory.GetBookForAuthor(authorId,bookId);
            if (targetBook==null)
            {
                return NotFound();
            }
            else
            {
                return targetBook;
            }
        }

    }
}

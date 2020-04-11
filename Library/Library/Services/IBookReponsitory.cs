using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.Services
{
    public interface IBookReponsitory
    {

        IEnumerable<BookDto> GetBooksForAuthor(Guid authorId);
        BookDto GetBookForAuthor(Guid authorId, Guid bookId);
    }
}

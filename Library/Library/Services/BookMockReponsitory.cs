using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class BookMockReponsitory : IBookReponsitory
    {
        public BookDto GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return LibraryMockData.Current.Books.FirstOrDefault(b=>b.AuthorId==authorId&&b.Id==bookId);
        }

        public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
        {
            return LibraryMockData.Current.Books.Where(b=>b.AuthorId==authorId).ToList();
        }
    }
}
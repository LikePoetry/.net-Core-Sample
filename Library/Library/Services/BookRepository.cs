using System;
using System.Collections.Generic;
using Library.API.Entities;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookRepository:RepositoryBase<Book, Guid>,IBookRepository
    {
        public BookRepository(DbContext dbContext):base(dbContext)
        {
        }

        public void AddBook(BookDto book)
        {
            LibraryMockData.Current.Books.Add(book);
        }

        public BookDto GetBookForAuthor(Guid authorId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}

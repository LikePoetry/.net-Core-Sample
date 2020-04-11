using System;
using System.Collections.Generic;
using Library.API.Entities;
using Library.Models;

namespace Library.Services
{
    public interface IBookRepository: IRepositoryBase<Book>, IRepositoryBase2<Book, Guid>
    {
        void AddBook(BookDto book);

        IEnumerable<BookDto> GetBooksForAuthor(Guid authorId);

        BookDto GetBookForAuthor(Guid authorId, Guid bookId);
    }
}

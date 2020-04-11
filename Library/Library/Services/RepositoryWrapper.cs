using System;
using Library.API.Entities;

namespace Library.Services
{
    public class RepositoryWrapper:IRepsitoryWrapper
    {
        private IAuthorReponsitory _authorReponsitory = null;
        private IBookRepository _bookRepository = null;
        public RepositoryWrapper(LibraryDbContext libraryDbContext)
        {
            LibraryDbContext = libraryDbContext;
        }
        public LibraryDbContext LibraryDbContext { get; }

        public IBookRepository Book => _bookRepository ?? new BookRepository(LibraryDbContext);

        public IAuthorReponsitory Author => _authorReponsitory ?? new AuthorRepository(LibraryDbContext);
    }
}

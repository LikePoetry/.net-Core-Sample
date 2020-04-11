using System;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookRepository:RepositoryBase<Book, Guid>,IBookRepository
    {
        public BookRepository(DbContext dbContext):base(dbContext)
        {
        }
    }
}

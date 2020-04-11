using System;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class AuthorRepository:RepositoryBase<Author,Guid>,IAuthorReponsitory
    {
        public AuthorRepository(DbContext dbContext):base(dbContext)
        {
        }
    }
}

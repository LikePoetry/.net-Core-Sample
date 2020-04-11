using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Entities;
using Library.Data;
using Library.Helper;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class AuthorRepository:RepositoryBase<Author,Guid>,IAuthorReponsitory
    {
        public AuthorRepository(DbContext dbContext):base(dbContext)
        {
        }

        public void AddAuthor(AuthorDto author)
        {
            author.Id = Guid.NewGuid();
            LibraryMockData.Current.Authors.Add(author);
        }

        public Task<PageList<Author>> GetAllAsync(AuthorresourceParameters parameters)
        {
            return Task.Run(() => {
                IQueryable<Author> queryableAuthors = DbContext.Set<Author>();
                var totalCount = queryableAuthors.Count();
                var items = queryableAuthors.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToList();
                return new PageList<Author>(items, totalCount, parameters.PageNumber, parameters.PageSize);
            });
        }

        public AuthorDto GetAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorExists(Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}

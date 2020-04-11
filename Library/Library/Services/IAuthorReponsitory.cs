using System;
using System.Threading.Tasks;
using Library.API.Entities;
using Library.Helper;
using Library.Models;

namespace Library.Services
{
    public interface IAuthorReponsitory:IRepositoryBase<Author>,IRepositoryBase2<Author,Guid>
    {
        IEnumerable<AuthorDto> GetAuthors();

        AuthorDto GetAuthor(Guid authorId);

        bool IsAuthorExists(Guid authorId);
        void AddAuthor(AuthorDto author);
        Task<PageList<Author>> GetAllAsync(AuthorresourceParameters parameters);
    }
}

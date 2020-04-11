using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.Services
{
    public interface IAuthorResponsitory
    {
        IEnumerable<AuthorDto> GetAuthors();

        AuthorDto GetAuthor(Guid authorId);

        bool IsAuthorExists(Guid authorId);
    }
}

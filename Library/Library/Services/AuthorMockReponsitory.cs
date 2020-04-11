using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class AuthorMockReponsitory:IAuthorResponsitory
    {
      public AuthorDto GetAuthor(Guid authorId)
        {
            var author = LibraryMockData.Current.Authors.FirstOrDefault(au => au.Id == authorId);
            return author;
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            return LibraryMockData.Current.Authors;
        }

       public bool IsAuthorExists(Guid authorId)
        {
            return LibraryMockData.Current.Authors.Any(au => au.Id == authorId);
        }
    }
}

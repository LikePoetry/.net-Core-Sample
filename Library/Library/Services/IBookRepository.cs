using System;
using Library.API.Entities;

namespace Library.Services
{
    public interface IBookRepository: IRepositoryBase<Book>, IRepositoryBase2<Book, Guid>
    {
    }
}

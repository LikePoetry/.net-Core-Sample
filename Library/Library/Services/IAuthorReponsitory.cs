using System;
using Library.API.Entities;

namespace Library.Services
{
    public interface IAuthorReponsitory:IRepositoryBase<Author>,IRepositoryBase2<Author,Guid>
    {
    }
}

using System;
namespace Library.Services
{
    public interface IRepsitoryWrapper
    {
        IBookRepository Book { get; }
        IAuthorReponsitory Author { get; }
    }
}

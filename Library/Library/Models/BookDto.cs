using System;
namespace Library.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Destription { get; set; }

        public int Pages { get; set; }

        public Guid AuthorId { get; set; }

    }
}

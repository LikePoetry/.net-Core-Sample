using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.Data
{
    public class LibraryMockData
    {
        public static LibraryMockData Current { get; } = new LibraryMockData();

        public List<AuthorDto> Authors { get; set; }

        public List<BookDto> Books { get; set; }

        public LibraryMockData()
        {
            Authors = new List<AuthorDto>
            {
                new AuthorDto
                {
                    Id=new Guid("72D5B5F5-3008-49B7-B0D6-CC337F1A3330"),
                    Name="Author 1",
                    Age=46,
                    Emain="sdai222797@xxx.com"
                },
                new AuthorDto
                {
                    Id=new Guid("7D04A48E-BE4E-468E-8CE2-3AC0A0C79549"),
                    Name="Author 2",
                    Age=43,
                    Emain="231151347@xxx.com"
                }

            };
            Books = new List<BookDto>
            {
                new BookDto
                {
                    Id=new Guid("7D8EBDA9-2634-4C0F-9469-0695D6123135"),
                    Title="Book1",
                    Destription="Description of book1",
                    Pages=281,
                    AuthorId=new Guid("72D5B5F5-3008-49B7-B0D6-CC337F1A3330")
                },
                new BookDto
                {
                    Id=new Guid("7D8EBDA9-2634-4C0F-9469-0695D6123189"),
                    Title="Book2",
                    Destription="Description of book2",
                    Pages=281,
                    AuthorId=new Guid("72D5B5F5-3008-49B7-B0D6-CC337F1A3330")
                },
                new BookDto
                {
                    Id=new Guid("7D8EBDA9-2674-4C0F-9469-0695D6123135"),
                    Title="Book3",
                    Destription="Description of book3",
                    Pages=281,
                    AuthorId=new Guid("7D04A48E-BE4E-468E-8CE2-3AC0A0C79549")
                },
                new BookDto
                {
                    Id=new Guid("7D8ABDA9-2634-4C0F-9469-0695D6123135"),
                    Title="Book4",
                    Destription="Description of book4",
                    Pages=281,
                    AuthorId=new Guid("7D04A48E-BE4E-468E-8CE2-3AC0A0C79549")
                }

            };
        }
    }
}

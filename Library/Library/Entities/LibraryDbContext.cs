using System;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Entities
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id=new Guid("7322ADFA-3242-AB56-B098-CC337F1A330"),
                    Name="Author 1",
                    BirthData=new DateTimeOffset(new DateTime(1960,11,11)),
                    Email="author@xxx.com"
                }
                );
        }
    }
}

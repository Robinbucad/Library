using Library.API.DTO;
using Library.API.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTest.Fixtures
{
    public static class BooksFixture
    {
        public static List<Book> GetListBooks() => new List<Book>
        {
            new Book
            {
                Title = "Libro 1",
                Description = "Gran libro",
                ISBN = "123"
            },
            new Book
            {
                Title = "Libro 2",
                Description = "Gran libro" ,
                ISBN = "1234" 
            },
            new Book
            {
                Title = "Libro 3",
                Description = "Gran libro" ,
                ISBN = "12345"
            }
        };
        public static BookDTO GetSingleBookDTO() => new BookDTO
        {
            Title = "Libro test",
            Description = "Gran libro test",
            ISBN = "12356"

        };

        public static Book GetSingleBook() => new Book
        {
            Title = "Libro test",
            Description = "Gran libro test",
            ISBN = "12356"

        };

        public static BookDTO PostBook() => new()
        {
            Title = "Libro test post",
            Description = "Gran libro test post",
            ISBN = "12356"

        };

        public static Book UpdateBook() => new Book
        {
            Title = "Libro update",
            Description = "Gran libro",
            ISBN = "1234"
        };

        public static BookDTO UpdateBookDTO() => new BookDTO
        {
            Title = "Libro update",
            Description = "Gran libro",
            ISBN = "1234"
        };

    }
}

using Library.API.Model;
using MongoDB.Bson;

namespace Library.API.DTO
{
    public class BookDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public BookDTO(Book book) 
        {
            Id = book.Id.ToString();
            Title = book.Title;
            Description = book.Description;
            ISBN = book.ISBN;

        }

        public BookDTO() { }

    }
}

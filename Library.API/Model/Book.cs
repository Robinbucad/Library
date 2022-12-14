using Library.API.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.API.Model
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

       public Book(BookDTO bookDTO) 
        {
            Title = bookDTO.Title;
            Description = bookDTO.Description;
            ISBN= bookDTO.ISBN;
        }

        public Book() { }
    }
}

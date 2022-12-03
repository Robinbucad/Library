using Library.API.Model;

namespace Library.API.Repository
{
    public interface IMongoRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookByIsbn(string ISBN);
        Task SaveBook(Book book);
        Task<Book> UpdateBook(Book book);
    }
}

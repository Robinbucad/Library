using Library.API.Model;

namespace Library.API.Service
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();

        Task SaveBook(Book book);

        Task<Book> GetBookByIsbn(string ISBN);

        Task<Book> UpdateBook(Book book);

    }
}

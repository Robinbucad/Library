using Library.API.DTO;
using Library.API.Model;

namespace Library.API.Service
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();

        Task<BookDTO> SaveBook(BookDTO book);

        Task<BookDTO> GetBookByIsbn(string ISBN);

        Task<BookDTO> UpdateBook(BookDTO book);

    }
}

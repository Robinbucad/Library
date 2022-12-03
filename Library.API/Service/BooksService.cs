using Library.API.Model;
using Library.API.Repository;

namespace Library.API.Service
{
    public class BooksService : IBookService
    {
        private readonly IMongoRepository _mongoRepository;

        public BooksService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public Task<List<Book>> GetAllBooks()
        {
            return _mongoRepository.GetAllBooks();
        }

        public async Task<Book> GetBookByIsbn(string ISBN)
        {
            return await _mongoRepository.GetBookByIsbn(ISBN);
         
            
        }

        public Task SaveBook(Book book)
        {
            return _mongoRepository.SaveBook(book);
        }

        public Task<Book> UpdateBook(Book book)
        {
            return _mongoRepository.UpdateBook(book);
        }

    }
}

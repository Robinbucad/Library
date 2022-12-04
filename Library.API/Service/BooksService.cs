using Library.API.DTO;
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

        public async Task<string> DeleteBook(string ISBN)
        {
            await _mongoRepository.DeleteBook(ISBN);

            return "Book deleted succesfully";
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            List<Book> bookList = await _mongoRepository.GetAllBooks();
            List<BookDTO> booksDTO= new();

            foreach (Book book in bookList)
            {
                BookDTO newBookDTO = new(book);
                booksDTO.Add(newBookDTO);
            }

            return booksDTO;
        }

        public async Task<BookDTO> GetBookByIsbn(string ISBN)
        {
           
            Book book = await _mongoRepository.GetBookByIsbn(ISBN);
            if(book == null)
            {
                throw new Exception("Book doesn't exist");
            }
            return new BookDTO(book);
         
        }

        public async Task<BookDTO> SaveBook(BookDTO book)
        {
            Book checkBook = await _mongoRepository.GetBookByIsbn(book.ISBN);

            if(checkBook != null) 
            {
                throw new Exception("Book already exist");
            }

            Book newBook = new(book);
             await _mongoRepository.SaveBook(newBook);

            return new BookDTO(newBook);
        }

        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            Book checkBook = await _mongoRepository.GetBookByIsbn(book.ISBN);

            if (checkBook == null)
            {
                throw new Exception("Book doesn't exist");
            }
            Book updatedBook = new(book);
            await _mongoRepository.UpdateBook(updatedBook);
            return new BookDTO(updatedBook);
        }

    }
}

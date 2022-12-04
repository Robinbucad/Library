using Library.API.DTO;
using Library.API.Model;
using Library.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BooksController(IBookService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            List<BookDTO> books = await _booksService.GetAllBooks();
            return Ok(books);
   
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetBookByIsbn(string isbn)
        {

            BookDTO book = await _booksService.GetBookByIsbn(isbn);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] BookDTO book)
        {
            await _booksService.SaveBook(book);
            return Created("Created", book);
        }   

        [HttpPut]
        public async Task<IActionResult> PutBook([FromBody] BookDTO book)
        {
            
            BookDTO checkBook = await _booksService.GetBookByIsbn(book.ISBN);

            if(checkBook != null)
            {
                BookDTO newBook = await _booksService.UpdateBook(book);
                return Ok(newBook);
            }
            return NotFound();
            
        }
       
       
    }
}
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
            List<Book> books = await _booksService.GetAllBooks();
            return Ok(books);
   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {

            Book book = await _booksService.GetBookByIsbn(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] Book book)
        {
            await _booksService.SaveBook(book);
            return Created("Created", book);
        }

        [HttpPut]
        public async Task<IActionResult> PutBook([FromBody] Book book)
        {
            
            Book newBook =await _booksService.UpdateBook(book);
            Book checkBook = await _booksService.GetBookByIsbn(book.ISBN);

            if(checkBook != null)
            {
                return Ok(newBook);
            }
            return NotFound();
            
        }

       
    }
}
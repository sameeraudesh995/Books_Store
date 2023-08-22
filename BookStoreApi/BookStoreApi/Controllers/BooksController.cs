using BookStore.Business.Services.BookService;
using BookStore.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var response = await _bookService.GetBookAsync();
            return Ok(response);
        }
        [HttpGet("{id:int}")] 
        public async Task<IActionResult> Get(int id)
        {
            var response = await _bookService.GetBookAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            var response = await _bookService.AddBookAsync(book);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            var response = await _bookService.UpdateBookAsync(id, book);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookService.DeleteBookAsync(id);
            return Ok(response);
        }

    }
}

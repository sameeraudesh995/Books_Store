using BookStore.Business.Services.BookService;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        private static List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                Author = "Author 1",
                Title = "Book 1",
                PublicationYear = 2022
            },
            new Book
            {
                Id = 2,
                Author = "Author 2",
                Title = "Book 2",
                PublicationYear = 2023
            }
        };

        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            var maxId = books.Max(b => b.Id);

            var newBook = new Book
            {
                Id = maxId + 1,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                Author = book.Author,
            };
            books.Add(newBook);
            return Ok(newBook);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
          var existingBook = books.FirstOrDefault(b => b.Id ==id);
            if (existingBook is null) 
            { 

                return NotFound();
            }

           existingBook.Title = book.Title;
           existingBook.PublicationYear = book.PublicationYear;
           existingBook.Author = book.Author;

            
            return Ok(existingBook);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            books.Remove(book);
            return Ok(book);
        }

    }
}

using BookStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.BookRepo
{
    public class BookRepository : IBookRepository
    {
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
        public async Task AddBookAsync(Book book)
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
           
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                //return NotFound();
            }

            books.Remove(book);
            
        }

        public async Task<IEnumerable<Book>> GetBookAsync()
        {
            return books;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            return book;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook is null)
            {

                //return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.Author = book.Author;


            
        }
    }
}

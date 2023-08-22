using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.Business.Services.BookService;

    public interface IBookService
    {

    Task<IEnumerable<Book>> GetBookAsync();

    Task<Book> GetBookAsync(int id);

    Task<string> AddBookAsync(Book book);

    Task<string> UpdateBookAsync(int id, Book book);

    Task<string> DeleteBookAsync(int id);
    }


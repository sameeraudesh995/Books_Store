using BookStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.BookRepo
{
    
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBookAsync();

        Task<Book> GetBookAsync(int id);

        Task AddBookAsync(Book book);

        Task UpdateBookAsync( Book book);

        Task DeleteBookAsync(int id);
    }
}

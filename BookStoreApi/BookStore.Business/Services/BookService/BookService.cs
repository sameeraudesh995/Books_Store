 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using BookStore.DataAccess.Models;
using BookStore.DataAccess.Repositories.BookRepo;

namespace BookStore.Business.Services.BookService;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetBookAsync()
        {
        var books = await _bookRepository.GetBookAsync(); 
        return books;
        }
        public async Task<Book> GetBookAsync(int id)
        {
        var book = await _bookRepository.GetBookAsync(id); 
        if (book is null)
        {
            //return NotFound();
        }
        return book;
    }

        public async Task<string> AddBookAsync(Book book)
        {
             try
             { 
                await _bookRepository.AddBookAsync(book);
             }
            catch (Exception ) 
            {
                throw;
            }
        return "Book Added Successfully";
        }

        public async Task<string> UpdateBookAsync(int id, Book book)
        {
        try
        {
            await _bookRepository.UpdateBookAsync( book);
        }
        catch (Exception)
        {
            throw;
        }

        return "Book Updated Successfully";
        }

        public async Task<string> DeleteBookAsync(int id)
        {
        try
        {
            await _bookRepository.DeleteBookAsync(id);
        }
        catch (Exception)
        {
            throw;
        }

        return "Book Successfully deleted";
        }

     
}  


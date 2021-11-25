using BooksApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Server.Services
{
    public interface IBookRepository
    {
        Task<List<Books>> GetBooksAsync();
        Task<Books> GetBookAsync(int id);
        Task SaveBookAsync(Books book);
        Task UpdateBookAsync(int id, Books book);
        Task<bool> DeleteBookAsync(int id);
    }
}


using BooksApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Client.Services
{
    public interface IBooksServices
    {
        Task<Books[]> GetBooks();
        Task<Books> GetBook(int id);
        Task PostBook(Books book);
        Task PutBook(int id, Books book);
        Task DeleteBook(int id);
    }
}

using BooksApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BooksApp.Client.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly HttpClient Http;
        private readonly string Url = "api/Books";

        public BooksServices(HttpClient client)
        {
            Http = client;
        }

        public async Task<Books[]> GetBooks()
        {
            return await Http.GetFromJsonAsync<Books[]>(Url);
        }

        public async Task<Books> GetBook(int id)
        {
            return await Http.GetFromJsonAsync<Books>($"{Url}/{id}");
        }

        public async Task PostBook(Books book)
        {
            await Http.PostAsJsonAsync(Url, book);
        }

        public async Task PutBook(int id, Books book)
        {
            await Http.PutAsJsonAsync($"{Url}/{id}", book);
        }

        public async Task DeleteBook(int id)
        {
            await Http.DeleteAsync($"{Url}/{id}");
        }

    }
}

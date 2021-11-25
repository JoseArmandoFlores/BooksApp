using BooksApp.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Rest
{
    public class BooksRestService
    {
        private readonly HttpClient client;

        public BooksRestService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Books");
        }

        public async Task<List<Books>> GetBooksRestAsync()
        {
            List<Books> books = new List<Books>();

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Books>>(content);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return books;
        }

        public async Task<Books> GetBookRestAsync(int id)
        {
            Books book = new Books();

            try
            {
                HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Books>(content);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return book;
        }

        public async Task AddBookRestAsync(Books book)
        {
            try
            {
                string payload = JsonConvert.SerializeObject(book);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                await client.PostAsync(client.BaseAddress, content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateBookRestAsync(int id, Books book)
        {
            try
            {
                string payload = JsonConvert.SerializeObject(book);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                await client.PutAsync($"{client.BaseAddress}/{id}", content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteBookRestAsync(int id)
        {
            bool isDeleted = false;

            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{client.BaseAddress}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return isDeleted;
        }
    }
}

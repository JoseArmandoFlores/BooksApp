using BooksApp.Server.Services;
using BooksApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices booksServices;

        public BooksController(IBookServices booksServices)
        {
            this.booksServices = booksServices;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> Get()
        {
            List<Books> books;

            books = await booksServices.GetBooksAsync();

            if (books.Count > 0)
            {
                return Ok(books);
            }

            return NoContent();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> Get(int id)
        {
            Books book;

            if (id > 0)
            {
                book = await booksServices.GetBookAsync(id);

                if (book == null)
                {
                    return NotFound(book);
                }
            }
            else
            {
                return NotFound($"Error 404: Book id: {id} not found");
            }

            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<Books>> Post([FromBody] Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            await booksServices.PostBookAsync(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Books book)
        {
            if (id > 0 && book != null)
            {
                await booksServices.PutBookAsync(id, book);
                return Ok();
            }

            return NotFound(id);
        }

        // DELETE api/<BooksController>/5
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = false;

            if (id > 0)
            {
                isDeleted = await booksServices.DeleteBookAsync(id);
                return Ok(isDeleted);
            }

            return NoContent();
        }
    }
}

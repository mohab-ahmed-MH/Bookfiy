using Bookfiy.Core.Interfaces;
using Bookfiy.Core.Models;
using Bookfiy.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookfiy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepositoty<Book> _bookRepositoty;
        public BooksController(IBaseRepositoty<Book> bookRepositoty)
        {
            _bookRepositoty = bookRepositoty;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_bookRepositoty.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok( _bookRepositoty.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId,
            };
            await _bookRepositoty.AddAsync(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateBookDto dto)
        {
            var book = _bookRepositoty.GetById(id);
            if (book == null)
                return NotFound($"NO book was found with ID:{id}");

            book.Title = dto.Title;
            book.AuthorId = dto.AuthorId;
            await _bookRepositoty.UpdateAsync(id, book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepositoty.GetById(id);
            if (book == null)
                return NotFound($"NO book was found with ID:{id}");
            _bookRepositoty.Delete(id, book);
            return Ok(book);
        }
    }
}

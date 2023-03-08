using Bookfiy.Core.Dtos;
using Bookfiy.Core.Interfaces;
using Bookfiy.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookfiy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepositoty<Author> _authorRepositoty;

        public AuthorsController(IBaseRepositoty<Author> authorRepositoty)
        {
            _authorRepositoty = authorRepositoty;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_authorRepositoty.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_authorRepositoty.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAuthorDto dto)
        {
            var author = new Author{ Name = dto.Name };
            await _authorRepositoty.AddAsync(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody]CreateAuthorDto dto)
        {
            var author = _authorRepositoty.GetById(id);
            if (author == null)
                return NotFound($"NO author was found with ID:{id}");

            author.Name = dto.Name;
            await _authorRepositoty.UpdateAsync(id, author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorRepositoty.GetById(id);
            if (author == null)
                return NotFound($"NO author was found with ID:{id}");
            _authorRepositoty.Delete(id, author);
            return Ok(author);
        }
    }
}

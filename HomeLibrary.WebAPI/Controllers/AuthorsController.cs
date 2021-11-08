using HomeLibrary.BLL.DTOs;
using HomeLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<AuthorDTO>>> Get()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> Get(int id)
        {
            return Ok(await _authorService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDTO author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newAuthor = await _authorService.AddAsync(author);
            return CreatedAtAction(nameof(Get), new { id = newAuthor.Id }, newAuthor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AuthorDTO author)
        {
            if (id != author.Id) ModelState.AddModelError("Id", "Input Id doesn't match.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _authorService.UpdateAsync(author);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}

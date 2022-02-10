using HomeLibrary.Shared.Dto;
using HomeLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeLibrary.DAL.Entities;

namespace HomeLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<AuthorDto>>> Get()
        {
            return Ok(_mapper.Map<ICollection<AuthorDto>>(await _authorService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            return Ok(_mapper.Map<AuthorDto>(await _authorService.GetByIdAsync(id)));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newAuthor = await _authorService.AddAsync(_mapper.Map<Author>(authorDto));
            return CreatedAtAction(nameof(Get), new { id = newAuthor.Id }, _mapper.Map<AuthorDto>(newAuthor));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AuthorDto authorDto)
        {
            if (id != authorDto.Id) ModelState.AddModelError("Id", "Input Id doesn't match.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _authorService.UpdateAsync(_mapper.Map<Author>(authorDto));
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

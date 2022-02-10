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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<BookDto>>> Get()
        {
            return Ok(_mapper.Map<ICollection<BookDto>>(await _bookService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return Ok(_mapper.Map<BookDto>(await _bookService.GetByIdAsync(id)));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newBook = await _bookService.AddAsync(_mapper.Map<Book>(bookDto));
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, _mapper.Map<BookDto>(newBook));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookDto bookDto)
        {
            if (id != bookDto.Id) ModelState.AddModelError("Id", "Input Id doesn't match.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _bookService.UpdateAsync(_mapper.Map<Book>(bookDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

    }
}

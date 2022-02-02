using AutoMapper;
using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL.Entities;
using HomeLibrary.Shared.Dto;
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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagsController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TagDto>>> Get()
        {
            return Ok(_mapper.Map<ICollection<TagDto>>(await _tagService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            return Ok(_mapper.Map<TagDto>(await _tagService.GetByIdAsync(id)));
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] TagDto tagDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newTag = await _tagService.AddAsync(_mapper.Map<Tag>(tagDto));
            return CreatedAtAction(nameof(Get), new { name = newTag.Name }, _mapper.Map<TagDto>(newTag));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tagService.DeleteAsync(id);
            return NoContent();
        }
    }
}

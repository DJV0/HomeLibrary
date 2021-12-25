using HomeLibrary.Shared.Dto;
using HomeLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLibrary.DAL.Entities;
using AutoMapper;

namespace HomeLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ImageDto>>> Get()
        {
            return Ok(_mapper.Map<ICollection<ImageDto>>(await _imageService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDto>> Get(int id)
        {
            return Ok(_mapper.Map<ImageDto>(await _imageService.GetByIdAsync(id)));
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ImageDto imageDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newImage = await _imageService.AddAsync(_mapper.Map<Image>(imageDto));
            return CreatedAtAction(nameof(Get), new { id = newImage.Id }, _mapper.Map<ImageDto>(newImage));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ImageDto imageDto)
        {
            if (id != imageDto.Id) ModelState.AddModelError("Id", "Input Id doesn't match.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _imageService.UpdateAsync(_mapper.Map<Image>(imageDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _imageService.DeleteAsync(id);
            return NoContent();
        }
    }
}

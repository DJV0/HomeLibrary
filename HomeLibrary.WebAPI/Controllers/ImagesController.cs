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
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ImageDTO>>> Get()
        {
            return Ok(await _imageService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> Get(int id)
        {
            return Ok(await _imageService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ImageDTO image)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newImage = await _imageService.AddAsync(image);
            return CreatedAtAction(nameof(Get), new { id = newImage.Id }, newImage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ImageDTO image)
        {
            if (id != image.Id) ModelState.AddModelError("Id", "Input Id doesn't match.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _imageService.UpdateAsync(image);
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

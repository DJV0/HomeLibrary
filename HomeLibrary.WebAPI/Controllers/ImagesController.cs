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
            var imageId = await _imageService.AddAsync(image);
            return CreatedAtAction(nameof(Get), new { id = imageId }, await _imageService.GetAsync(imageId));
        }
    }
}

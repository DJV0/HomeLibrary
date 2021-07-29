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
    }
}

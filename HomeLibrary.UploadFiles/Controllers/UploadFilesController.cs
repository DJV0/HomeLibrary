using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.UploadFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UploadFilesController : ControllerBase
    {
        public UploadFilesService UploadFilesService { get; set; }

        public UploadFilesController(UploadFilesService service)
        {
            UploadFilesService = service;
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<string>> Upload([FromForm] IFormFileCollection files)
        {
            var uri = await UploadFilesService.UploadAsync(files);
            return Ok(uri);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hmd_api.Controllers
{
    [Route("tracks")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] files = Directory.GetFiles(UploadController.uploadPath);

            return Ok(new { tracks = files });
        }
    }
}
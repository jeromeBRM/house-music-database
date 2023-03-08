using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hmd_api.Model;
using hmd_api.Requests;
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

            foreach(string file in files)
            {
                IApiObject track = new Track(file);
            }

            return Ok(new { tracks = files });
        }
    }
}
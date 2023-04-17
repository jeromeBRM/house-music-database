using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hmd_api.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hmd_api.Controllers
{
    [Route("update")]
    [ApiController]
    [EnableCors]
    public class UpdateApiObjectController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] string apiObjectId, [FromForm] string property, [FromForm] string value)
        {
            Track track = HmdAPI.GetInstance().GetTrack(apiObjectId);

            // refactor needed

            if (property == "name")
            {
                track.Name = value;
            }

            HmdAPI.GetInstance().Export<Track>(track);

            return Ok();
        }
    }
}
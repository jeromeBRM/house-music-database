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
    public class UpdateApiObjectController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("updated.");
        }
    }
}
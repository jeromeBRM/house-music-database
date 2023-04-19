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
    [Route("scales")]
    [ApiController]
    public class ScalesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(HmdAPI.GetInstance().Scales());
        }
    }
}
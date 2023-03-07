using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hmd_api.Model;
using hmd_api.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hmd_api.Controllers
{
    [Route("clear-database")]
    [ApiController]
    public class ClearDatabaseController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            new ClearApiObjectsRequest().Execute();
            return new String("database cleared.");
        }
    }
}
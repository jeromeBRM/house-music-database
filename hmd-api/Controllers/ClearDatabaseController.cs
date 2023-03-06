using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hmd_api.Model;
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
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw("delete from api_objects");
            return new String("database cleared.");
        }
    }
}
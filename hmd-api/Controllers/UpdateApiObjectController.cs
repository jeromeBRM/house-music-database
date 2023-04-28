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
            /* 
             * refactor needed!
             * 
             */

            if (HmdAPI.GetInstance().GetTrack(apiObjectId) != null)
            {
                Track track = HmdAPI.GetInstance().GetTrack(apiObjectId);

                if (property == "name")
                {
                    track.Name = value;
                }

                HmdAPI.GetInstance().Export<Track>(track);
            }

            else if (HmdAPI.GetInstance().GetScale(apiObjectId) != null)
            {
                Scale scale = HmdAPI.GetInstance().GetScale(apiObjectId);

                if (property == "value")
                {
                    scale.Value = int.Parse(value);
                }

                HmdAPI.GetInstance().Export<Scale>(scale);
            }

            return Ok();
        }
    }
}
﻿using System;
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
        public IActionResult Get(string id)
        {
            return id == null ? Ok(HmdAPI.GetInstance().Tracks()) : Ok(HmdAPI.GetInstance().GetTrack(id));
        }
    }
}
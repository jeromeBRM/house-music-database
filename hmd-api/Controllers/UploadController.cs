﻿using System;
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
    [EnableCors]
    [Route("upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        public static string uploadPath = "uploads";
        private static string allowedAudioExtension = ".mp3";

        [HttpPost]
        [RequestSizeLimit(20_000_000)]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            int successes = 0;
            int errors = 0;

            foreach (IFormFile formFile in files)
            {
                if (formFile.Length > 0)
                {
                    int filesCount = Directory.GetFiles(UploadController.uploadPath).Length;
                    string filePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), UploadController.uploadPath, formFile.FileName));

                    if (System.IO.Path.GetExtension(filePath) == UploadController.allowedAudioExtension)
                    {
                        using (FileStream stream = System.IO.File.Create(filePath))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (Directory.GetFiles(UploadController.uploadPath).Length > filesCount)
                        {
                            // add new track if created

                            HmdAPI.GetInstance().AddNewTrack(formFile.FileName).RenameFile();
                            successes++;
                        }
                    }
                    else
                    {
                        errors++;
                    }
                }
            }

            return Ok(new { successes = successes, errors = errors });
        }
    }
}
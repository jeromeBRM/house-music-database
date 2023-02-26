using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private static string uploadPath = "./uploads";

        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    if (!System.IO.Directory.Exists(UploadController.uploadPath))
                    {
                        System.IO.Directory.CreateDirectory(UploadController.uploadPath);
                    }

                    var filePath = Path.Combine(UploadController.uploadPath, formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new { count = files.Count, size });
        }
    }
}
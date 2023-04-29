using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hmd_api.Controllers;
using hmd_api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using hmd_api.Requests;

namespace hmd_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // refactor directory/file creation in the future :

            // local.db creation

            if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Database/local.db")))
            {
                System.IO.Directory.CreateDirectory("Database");
                using (FileStream fs = File.Create(Path.Combine(Directory.GetCurrentDirectory(), "Database/local.db")));
            }

            // backup directory creation

            if (!System.IO.Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Backup")))
            {
                System.IO.Directory.CreateDirectory("Backup");
            }

            if (!System.IO.Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Backup/uploads")))
            {
                System.IO.Directory.CreateDirectory("Backup/uploads");
            }

            // uploads directory creation

            if (!System.IO.Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), UploadController.uploadPath)))
            {
                System.IO.Directory.CreateDirectory(UploadController.uploadPath);
            }

            HmdAPI.Create(configuration);

            new SetupDatabaseRequest().Execute();

            HmdAPI.GetInstance().RestoreState();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            string[] allowedOrigins = { "http://test.infodoo.com", "http://localhost:4200" };

            app.UseCors(
                options => options.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader()
            );

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                                    Path.Combine(Directory.GetCurrentDirectory(), UploadController.uploadPath)),
                RequestPath = new PathString(Path.Combine("/", UploadController.uploadPath))
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
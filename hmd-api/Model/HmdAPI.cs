using hmd_api.Controllers;
using hmd_api.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public sealed class HmdAPI
    {
        private static HmdAPI instance;

        private static IConfiguration configuration;
        private static SQLiteContext dbContext;

        private static LinkedList<IApiObject> apiObjects;

        private HmdAPI(IConfiguration configuration)
        {
            HmdAPI.configuration = configuration;
            HmdAPI.dbContext = new SQLiteContext(configuration);
            HmdAPI.apiObjects = new LinkedList<IApiObject>();
        }

        public void RestoreState()
        {
            string[] files = Directory.GetFiles(UploadController.uploadPath);

            IApiObjectFactory<Track> trackFactory = new ApiObjectFactory<Track>();

            foreach (string file in files)
            {
                IApiObject track = trackFactory.Create(new SQLApiObject());
            }
        }

        public void Export<T> (T apiObject) where T : IApiObject
        {
            new ExportApiObjectRequest().Execute(
                new string[]
                {
                    apiObject.Id(),
                    apiObject.Type(),
                    JsonSerializer.Serialize<T>(apiObject)
                });
        }

        public IConfiguration GetConfiguration()
        {
            return HmdAPI.configuration;
        }

        public SQLiteContext GetDbContext()
        {
            return HmdAPI.dbContext;
        }

        public static HmdAPI Create(IConfiguration configuration)
        {
            if (HmdAPI.instance == null)
            {
                HmdAPI.instance = new HmdAPI(configuration);
            }
            return HmdAPI.instance;
        }

        public static HmdAPI GetInstance()
        {
            if (HmdAPI.instance == null)
            {
                // not created exception
                throw new Exception();
            }
            return HmdAPI.instance;
        }
    }
}
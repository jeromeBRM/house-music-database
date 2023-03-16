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

        private LinkedList<IApiObject> apiObjects;

        private LinkedList<Track> tracks;

        private HmdAPI(IConfiguration configuration)
        {
            HmdAPI.configuration = configuration;
            HmdAPI.dbContext = new SQLiteContext(configuration);
            this.apiObjects = new LinkedList<IApiObject>();
            this.tracks = new LinkedList<Track>();
        }

        public void RestoreState()
        {
            //this.RegisterNewlyAddedTracks();
            this.RestoreAll<Track>().ForEach(track => {
                this.apiObjects.AddLast(track);
                this.tracks.AddLast(track);
            });
        }

        private List<T> RestoreAll<T>() where T : IApiObject, new()
        {
            IApiObjectFactory<T> factory = new ApiObjectFactory<T>();

            List<SQLApiObject> sqlApiObjects = new GetApiObjectsByTypeRequest().Select(new string[] { new Track().Type() });

            List<T> restoredApiObjects = new List<T>();

            foreach (SQLApiObject sqlApiObject in sqlApiObjects)
            {
                restoredApiObjects.Add(factory.Create(sqlApiObject));
            }

            return restoredApiObjects;
        }

        private void RegisterNewlyAddedTracks()
        {
            string[] files = Directory.GetFiles(UploadController.uploadPath);

            IApiObjectFactory<Track> trackFactory = new ApiObjectFactory<Track>();

            foreach (string file in files)
            {
                SQLApiObject sqlApiObject = new SQLApiObject().AddProperty("Source", file);
                IApiObject track = trackFactory.Create(sqlApiObject);
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

        public LinkedList<IApiObject> ApiObjects()
        {
            return this.apiObjects;
        }

        public LinkedList<Track> Tracks()
        {
            return this.tracks;
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
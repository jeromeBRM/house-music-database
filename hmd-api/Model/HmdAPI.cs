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

        private List<IApiObject> apiObjects;

        private List<Track> tracks;

        private HmdAPI(IConfiguration configuration)
        {
            HmdAPI.configuration = configuration;
            HmdAPI.dbContext = new SQLiteContext(configuration);
            this.apiObjects = new List<IApiObject>();
            this.tracks = new List<Track>();
        }

        public void RestoreState()
        {
            string[] files = Directory.GetFiles(UploadController.uploadPath);

            this.RestoreAll<Track>().ForEach(track => {
                this.apiObjects.Add(track);
                this.tracks.Add(track);
            });

            foreach (string file in files)
            {
                bool found = false;

                this.tracks.ForEach(track => {
                    if (file.Equals(track.Source))
                    {
                        found = true;
                    }
                });

                if (!found)
                {
                    this.AddNewTrack(file);
                }
            }
        }

        private List<T> RestoreAll<T>() where T : IApiObject, new()
        {
            IApiObjectFactory<T> factory = new ApiObjectFactory<T>();

            List<SQLApiObject> sqlApiObjects = new GetApiObjectsByTypeRequest().Select(new string[] { new T().Type() });

            List<T> restoredApiObjects = new List<T>();

            foreach (SQLApiObject sqlApiObject in sqlApiObjects)
            {
                restoredApiObjects.Add(factory.Create(sqlApiObject));
            }

            return restoredApiObjects;
        }

        public void AddNewTrack(string file)
        {
            IApiObjectFactory<Track> trackFactory = new ApiObjectFactory<Track>();

            Track track = new Track(file);
            SQLApiObject sqlApiObject = new SQLApiObject(JsonSerializer.Serialize<Track>(track));

            trackFactory.Create(sqlApiObject);

            this.tracks.Add(track);
            this.apiObjects.Add(track);
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

        public List<IApiObject> ApiObjects()
        {
            return this.apiObjects;
        }

        public List<Track> Tracks()
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
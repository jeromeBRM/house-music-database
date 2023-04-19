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

        // api objects
        private List<Track> tracks;
        private List<TrackProfile> trackProfiles;
        private List<Scale> scales;

        private HmdAPI(IConfiguration configuration)
        {
            HmdAPI.configuration = configuration;
            HmdAPI.dbContext = new SQLiteContext(configuration);
            
            this.apiObjects = new List<IApiObject>();
            this.tracks = new List<Track>();
            this.trackProfiles = new List<TrackProfile>();
            this.scales = new List<Scale>();
        }

        public void RestoreState()
        {
            this.RestoreAll<TrackProfile>().ForEach(trackProfile => {
                this.apiObjects.Add(trackProfile);
                this.trackProfiles.Add(trackProfile);
            });

            this.RestoreAll<Track>().ForEach(track => {
                this.apiObjects.Add(track);
                this.tracks.Add(track);
            });

            foreach (string file in Directory.GetFiles(UploadController.uploadPath))
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
            Track track = new Track(file);

            this.AddNewTrackProfile(track);

            this.tracks.Add(track);
            this.apiObjects.Add(track);

            Export(track);
        }

        public void AddNewTrackProfile(Track track)
        {
            TrackProfile trackProfile = new HouseTrackProfile(track.Id);

            track.TrackProfile = trackProfile.Id;

            this.trackProfiles.Add(trackProfile);
            this.apiObjects.Add(trackProfile);

            Export(trackProfile);
        }

        public void Export<T> (T apiObject) where T : IApiObject
        {
            new ExportApiObjectRequest().Execute(
                new string[]
                {
                    apiObject.GetId(),
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

        public List<TrackProfile> TrackProfiles()
        {
            return this.trackProfiles;
        }

        public List<Scale> Scales()
        {
            return this.scales;
        }

        public Track GetTrack(string id)
        {
            Track track = null;

            foreach(Track t in this.Tracks())
            {
                if (t.Id.Equals(id))
                {
                    track = t;
                }
            }
            return track;
        }

        public TrackProfile GetTrackProfile(string id)
        {
            TrackProfile trackProfile = null;

            foreach (TrackProfile tp in this.TrackProfiles())
            {
                if (tp.Id.Equals(id))
                {
                    trackProfile = tp;
                }
            }
            return trackProfile;
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
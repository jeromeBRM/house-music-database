using hmd_api.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace hmd_api.Model
{
    public class Track : ApiObject
    {
        private string name;
        private HashSet<Author> authors;
        private string source;
        private TrackProfile trackProfile;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Source { get { return this.source; } set { this.source = value; } }
        public string TrackProfile {
            get
            {
                return trackProfile.Id;
            }
            set
            {
                this.trackProfile = HmdAPI.GetInstance().GetTrackProfile(value);
            }
        }

        public Track() { }

        public Track(string source) : base()
        {
            this.name = "";
            this.RenameFile(source);
            this.trackProfile = new HouseTrackProfile(this.Id);
            HmdAPI.GetInstance().AddNewTrackProfile(this.trackProfile);
        }

        public TrackProfile GetProfile()
        {
            return this.trackProfile;
        }

        public void SetProfile(TrackProfile trackProfile)
        {
            this.trackProfile = trackProfile;
        }

        private void RenameFile(string source)
        {
            string newName = this.Id + "_" + source;

            string oldPath = Path.Combine(Directory.GetCurrentDirectory(), UploadController.uploadPath, source);
            string newPath = Path.Combine(Directory.GetCurrentDirectory(), UploadController.uploadPath, newName);

            File.Move(oldPath, newPath);
            this.Source = newName;
        }

        public override void Restore(SQLApiObject sqlApiObject)
        {
            base.Restore(sqlApiObject);
            
            if (sqlApiObject.value != null)
            {
                Track trackDatas = JsonSerializer.Deserialize<Track>(sqlApiObject.value);
                this.Source = trackDatas.Source;
                this.Name = trackDatas.Name;
                this.TrackProfile = trackDatas.TrackProfile;
            }
        }

        public override string Type()
        {
            return new String("hmd-tracks");
        }
    }
}
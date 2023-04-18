using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Track : ApiObject
    {
        private string name;
        private HashSet<Author> authors;
        private string source;
        private string trackProfile;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Source { get { return this.source; } set { this.source = value; } }
        public string TrackProfile {
            get
            {
                return trackProfile;
            }
            set
            {
                this.trackProfile = value;
            }
        }

        public Track() { }

        public Track(string source) : base()
        {
            this.name = "";
            this.source = source;
        }

        public TrackProfile GetProfile()
        {
            return HmdAPI.GetInstance().GetTrackProfile(this.trackProfile);
        }

        public void SetProfile(TrackProfile trackProfile)
        {
            this.trackProfile = trackProfile.Id;
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
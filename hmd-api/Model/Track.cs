using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Track : ApiObject, IProfilable
    {
        private string name;
        private HashSet<Author> authors;
        private string source;
        private TrackProfile trackProfile;

        public string Source { get { return this.source; } set { } }

        public Track() { }

        public Track(string source) : base()
        {
            this.source = source;
            this.authors = new HashSet<Author>();
            this.trackProfile = new HouseTrackProfile(this);
        }

        public Track(string name, HashSet<Author> authors)
        {
            this.name = name;
            this.authors = authors;
        }

        public TrackProfile GetProfile()
        {
            return this.trackProfile;
        }

        public void SetProfile(TrackProfile trackProfile)
        {
            this.trackProfile = trackProfile;
        }

        public override void Restore(SQLApiObject sqlApiObject)
        {
            base.Restore(sqlApiObject);
            this.source = sqlApiObject.GetProperty<string>("Source");
        }

        public override string Type()
        {
            return new String("hmd-tracks");
        }
    }
}
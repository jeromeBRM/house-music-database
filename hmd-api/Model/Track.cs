using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Track : Identifiable, IProfilable
    {
        private string name;
        private HashSet<Author> authors;
        private TrackProfile trackProfile;

        public Track(string name)
        {
            this.name = name;
            this.authors = new HashSet<Author>();
            //this.trackProfile = new TrackProfile(this);
        }

        public Track(string name, HashSet<Author> authors)
        {
            this.name = name;
            this.authors = authors;
        }

        public TrackProfile getProfile()
        {
            return this.trackProfile;
        }

        public void setProfile(TrackProfile trackProfile)
        {
            this.trackProfile = trackProfile;
        }

        public override string getTableName()
        {
            return new String("hmd-tracks");
        }
    }
}

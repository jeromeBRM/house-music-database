using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class TrackProfile : ApiObject
    {
        protected HashSet<Scale> scales;

        public TrackProfile() { }

        public TrackProfile(string profilableId) : base()
        {
            this.scales = new HashSet<Scale>();
            this.SetScales();
        }

        public HashSet<Scale> GetScales()
        {
            return this.scales;
        }

        public virtual void SetScales()
        {

        }

        public override void Restore(SQLApiObject sqlApiObject)
        {
            base.Restore(sqlApiObject);
        }

        public override string Type()
        {
            return new String("hmd-profiles");
        }
    }
}
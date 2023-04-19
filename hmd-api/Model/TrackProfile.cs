using System;
using System.Collections.Generic;
using System.Text.Json;

namespace hmd_api.Model
{
    public class TrackProfile : ApiObject
    {
        protected HashSet<Scale> scales;

        public List<string> Scales
        {
            get
            {
                List<string> scales = new List<string>();
                foreach (Scale scale in this.scales)
                {
                    scales.Add(scale.Id);
                }
                return scales;
            }
            set
            {
                this.scales = new HashSet<Scale>();
                foreach (string scale in value)
                {
                    this.scales.Add(HmdAPI.GetInstance().GetScale(scale));
                }
            }
        }

        public TrackProfile() { }

        public TrackProfile(string profilableId) : base()
        {
            this.scales = new HashSet<Scale>();
            this.SetScales();
            foreach (Scale scale in this.scales)
            {
                HmdAPI.GetInstance().AddNewScale(scale);
            }
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

            if (sqlApiObject.value != null)
            {
                TrackProfile trackDatas = JsonSerializer.Deserialize<TrackProfile>(sqlApiObject.value);
                this.Scales = trackDatas.Scales;
            }
        }

        public override string Type()
        {
            return new String("hmd-profiles");
        }
    }
}
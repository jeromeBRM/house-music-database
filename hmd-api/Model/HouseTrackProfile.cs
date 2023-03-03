using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class HouseTrackProfile : TrackProfile
    {
        public HouseTrackProfile(IProfilable profilable) : base(profilable)
        {
        }

        public override void SetScales()
        {
            base.scales.Add(new DeepScale());
            base.scales.Add(new DreamScale());
            base.scales.Add(new DecayScale());
        }
    }
}
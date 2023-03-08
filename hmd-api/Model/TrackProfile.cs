using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class TrackProfile : ApiObject
    {
        private IProfilable profilable;
        protected HashSet<Scale> scales;

        public TrackProfile(IProfilable profilable)
        {
            this.profilable = profilable;
            this.scales = new HashSet<Scale>();
            this.SetScales();
        }

        public HashSet<Scale> GetScales()
        {
            return this.scales;
        }

        public abstract void SetScales();

        public override string Type()
        {
            return new String("hmd-profiles");
        }
    }
}
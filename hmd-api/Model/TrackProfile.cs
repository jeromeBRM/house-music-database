using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class TrackProfile : Identifiable
    {
        private IProfilable profilable;
        protected HashSet<Scale> scales;

        public TrackProfile(IProfilable profilable)
        {
            this.profilable = profilable;
            this.SetScales();
        }

        public HashSet<Scale> GetScales()
        {
            return this.scales;
        }

        public abstract void SetScales();

        public override string GetTableName()
        {
            return new String("hmd-profiles");
        }
    }
}
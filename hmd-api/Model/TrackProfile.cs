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
            this.setScales();
        }

        public HashSet<Scale> getScales()
        {
            return this.scales;
        }

        public abstract void setScales();

        public override string getTableName()
        {
            return new String("hmd-profiles");
        }
    }
}
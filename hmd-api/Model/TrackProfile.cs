using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class TrackProfile : Identifiable
    {
        private IProfilable profilable;

        public TrackProfile(IProfilable profilable)
        {
            this.profilable = profilable;
        }

        public override string getTableName()
        {
            return new String("hmd-profiles");
        }
    }
}
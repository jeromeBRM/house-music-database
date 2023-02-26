using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class DreamScale : Scale
    {
        public override string getName()
        {
            return new String("Dream");
        }

        public override string getDescription()
        {
            return new String("The dream scale measures a track's ability to convey deep emotions and take the listener on a journey through the use of reverb, sound spatialization and out-of-time sounds. A track with a high dream value is contemplative and conducive to melancholia, hope, or nostaglia, while a track with a low dream value tends to be more danceable.");
        }
    }
}
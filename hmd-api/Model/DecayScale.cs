using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class DecayScale : Scale
    {
        public override string getName()
        {
            return new String("Decay");
        }

        public override string getDescription()
        {
            return new String("The decay scale quantifies the overall sound quality of a track. A track with high decay level tends to feature low-quality samples, saturated effects and the use of bandpass filters in order to convey a worn out aesthetic.");
        }
    }
}

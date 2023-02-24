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
            return new String("");
        }
    }
}

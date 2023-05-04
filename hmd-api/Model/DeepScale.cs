using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class DeepScale : Scale
    {
        public override string GetName()
        {
            return new String("Deep");
        }

        public override string GetDescription()
        {
            return new String("A deep track features a straightforward bassline structure and focuses the listener's attention on low frenquencies. It includes a rich beat presence and a simple, sometimes muffled yet very essential bassline.");
        }

        public override string Type()
        {
            return new String("hmd-deep-scales");
        }
    }
}
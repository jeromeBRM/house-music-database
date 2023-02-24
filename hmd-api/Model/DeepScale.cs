using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class DeepScale : Scale
    {
        public override string getName()
        {
            return new String("Deep");
        }

        public override string getDescription()
        {
            return new String("A deep track features a straightforward bassline structure and focuses the listener's attention on low frenquencies. It includes a rich beat presence and a simple, sometimes muffled yet very essential bassline.");
        }
    }
}

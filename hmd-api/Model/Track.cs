using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Track : Identifiable
    {
        public override string getTableName()
        {
            return new String("hmd-tracks");
        }
    }
}

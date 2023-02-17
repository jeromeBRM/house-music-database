using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class Identifiable : IIdentifiable
    {
        private string id;

        public string getId()
        {
            return this.id;
        }

        public abstract string getTableName();
    }
}

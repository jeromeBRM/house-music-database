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

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Identifiable identifiable = (Identifiable)obj;

            return this.getId().Equals(identifiable.getId());
        }
    }
}

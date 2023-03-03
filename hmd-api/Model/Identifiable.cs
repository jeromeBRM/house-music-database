using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class Identifiable : IIdentifiable
    {
        private string id;

        public string GetId()
        {
            return this.id;
        }

        public abstract string GetTableName();

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Identifiable identifiable = (Identifiable)obj;

            return this.GetId().Equals(identifiable.GetId());
        }
    }
}
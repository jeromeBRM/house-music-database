using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class ApiObject : IApiObject
    {
        private string id;

        public string Id()
        {
            return this.id;
        }

        public abstract string Type();

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            ApiObject apiObject = (ApiObject)obj;

            return this.Id().Equals(apiObject.Id());
        }
    }
}
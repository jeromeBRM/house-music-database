using hmd_api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class ApiObject : IApiObject
    {
        private string id;

        public string Id { get { return this.id; } set { this.id = value; } }

        public ApiObject()
        {
            this.id = new UniqueId().Get();
        }

        public abstract string Type();

        public virtual void Restore(SQLApiObject sqlApiObject)
        {
            if (sqlApiObject.id != null)
            {
                this.id = sqlApiObject.id;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            ApiObject apiObject = (ApiObject)obj;

            return this.GetId().Equals(apiObject.GetId());
        }

        public string GetId()
        {
            return this.Id;
        }
    }
}
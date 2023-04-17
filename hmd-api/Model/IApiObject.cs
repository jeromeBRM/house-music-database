using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public interface IApiObject
    {
        public string GetId();
        public abstract string Type();
        public abstract void Restore(SQLApiObject sqlApiObject);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public interface IApiObject
    {
        public string Id();
        public abstract string Type();
        public abstract void Export<T>(T apiObject);
    }
}
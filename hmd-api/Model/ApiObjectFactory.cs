using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class ApiObjectFactory<T> : IApiObjectFactory<T> where T : IApiObject, new()
    {
        public T Create(SQLApiObject sqlApiObject)
        {
            T apiObject = new T();
            apiObject.Restore(sqlApiObject);
            return apiObject;
        }
    }
}
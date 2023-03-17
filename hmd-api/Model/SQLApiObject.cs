using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class SQLApiObject
    {
        public string id { get; set; }
        public string type { get; set; }
        public string value { get; set; }

        private Dictionary<string, object> datas;

        public SQLApiObject()
        {
            this.datas = new Dictionary<string, object>();
        }

        public SQLApiObject(string value)
        {
            this.datas = new Dictionary<string, object>();
            this.value = value;
        }

        public SQLApiObject AddProperty<T>(string key, T value)
        {
            this.datas.Add(key, value);
            return this;
        }

        public Dictionary<string, object> Datas()
        {
            return this.datas;
        }

        public T GetProperty<T>(string key)
        {
            return (T) this.datas[key];
        }
    }
}
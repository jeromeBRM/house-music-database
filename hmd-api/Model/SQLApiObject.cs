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

        public SQLApiObject(Dictionary<string, object> datas)
        {
            this.datas = datas;
        }

        public void AddData(string attribute, object o)
        {
            this.datas.Add(attribute, o);
        }

        public Dictionary<string, object> Datas()
        {
            return this.datas;
        }
    }
}
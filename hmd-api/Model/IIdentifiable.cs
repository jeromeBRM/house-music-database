using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    interface IIdentifiable
    {
        public string GetId();
        public abstract string GetTableName();
    }
}
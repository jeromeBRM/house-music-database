using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class Identifiable : IIdentifiable
    {
        private string id;
        private string tableName;

        public abstract string getId();

        public abstract string getTableName();
    }
}

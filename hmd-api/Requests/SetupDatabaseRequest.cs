using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Requests
{
    public class SetupDatabaseRequest : Request
    {
        protected override string RequestBody()
        {
            return new String("create table if not exists api_objects (id text, type text not null, value text not null, constraint pk_api_objects primary key(id));");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Requests
{
    public class ClearApiObjectsRequest : Request
    {
        protected override string RequestBody()
        {
            return new String("delete from api_objects;");
        }
    }
}
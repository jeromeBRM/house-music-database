using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace hmd_api.Requests
{
    internal class GetApiObjectsRequest : Request
    {
        public override List<SQLApiObject> Select()
        {
            return HmdAPI.GetInstance().GetDbContext().SQLApiObjects.FromSqlRaw(this.RequestBody()).ToList();
        }

        protected override string RequestBody()
        {
            return new String(@"select * from api_objects;");
        }
    }
}
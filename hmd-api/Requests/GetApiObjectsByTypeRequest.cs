using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace hmd_api.Requests
{
    internal class GetApiObjectsByTypeRequest : Request
    {
        public override List<SQLApiObject> Select(string[] parameters)
        {
            return HmdAPI.GetInstance().GetDbContext().SQLApiObjects.FromSqlRaw(
                this.RequestBody(),
                new SqliteParameter("@type", parameters[0]))
                .ToList();
        }

        protected override string RequestBody()
        {
            return new String(@"select * from api_objects where type = @type;");
        }
    }
}
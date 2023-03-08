using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace hmd_api.Requests
{
    internal class ExportApiObjectRequest : Request
    {
        public override void Execute(string[] parameters)
        {
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw(
                this.RequestBody(),
                new SqliteParameter("@id", parameters[0]),
                new SqliteParameter("@type", parameters[1]),
                new SqliteParameter("@value", parameters[2]));
        }

        protected override string RequestBody()
        {
            return new String(@"replace into api_objects (id, type, value) values (@id, @type, @value);");
        }
    }
}
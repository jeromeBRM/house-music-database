using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace hmd_api.Requests
{
    internal class InsertNewApiObject : Request
    {
        public InsertNewApiObject(string[] parameters) : base(parameters)
        {
        }

        public override void Execute()
        {
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw(
                this.RequestBody(),
                new SqliteParameter("@id", base.parameters[0]),
                new SqliteParameter("@type", base.parameters[1]),
                new SqliteParameter("@value", base.parameters[2]));
        }

        protected override string RequestBody()
        {
            return new String(@"insert into api_objects (id, type, value) values (@id, @type, @value);");
        }
    }
}
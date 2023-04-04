using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace hmd_api.Requests
{
    internal class DeleteApiObjectRequest : Request
    {
        public override void Execute(string[] parameters)
        {
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw(
                this.RequestBody(),
                new SqliteParameter("@id", parameters[0]));
        }

        protected override string RequestBody()
        {
            return new String(@"delete from api_objects where id = @id;");
        }
    }
}
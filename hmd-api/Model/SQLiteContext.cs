using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace hmd_api.Model
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(HmdAPI.GetInstance().GetConfiguration().GetConnectionString("WebApiDatabase"));
        }
    }
}
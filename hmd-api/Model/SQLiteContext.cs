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
        private IConfiguration configuration;

        public SQLiteContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(this.configuration.GetConnectionString("WebApiDatabaseSource"));
        }
    }
}
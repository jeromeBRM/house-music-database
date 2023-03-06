using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public sealed class HmdAPI
    {
        private static HmdAPI instance;

        private static IConfiguration configuration;
        private static DbContext dbContext;

        private HmdAPI(IConfiguration configuration)
        {
            HmdAPI.configuration = configuration;
            HmdAPI.dbContext = new SQLiteContext(configuration);

            this.SetupDatabase();
            
            if (this.InsertIntoDatabaseTest() != 1)
            {
                throw new InvalidOperationException();
            }
        }

        private void SetupDatabase()
        {
            string setupSchemaQuery = File.ReadAllText(HmdAPI.configuration.GetConnectionString("WebApiDatabaseSchema"));
            HmdAPI.dbContext.Database.ExecuteSqlRaw(setupSchemaQuery);
        }

        private int InsertIntoDatabaseTest()
        {
            return HmdAPI.dbContext.Database.ExecuteSqlRaw("insert into api_objects (id, type, value) values (\"j5d9z5d4\", \"test\", \"hello world!\");");
        }

        public IConfiguration GetConfiguration()
        {
            return HmdAPI.configuration;
        }

        public DbContext GetDbContext()
        {
            return HmdAPI.dbContext;
        }

        public static HmdAPI Create(IConfiguration configuration)
        {
            if (HmdAPI.instance == null)
            {
                HmdAPI.instance = new HmdAPI(configuration);
            }
            return HmdAPI.instance;
        }

        public static HmdAPI GetInstance()
        {
            if (HmdAPI.instance == null)
            {
                // not created exception
                throw new Exception();
            }
            return HmdAPI.instance;
        }
    }
}
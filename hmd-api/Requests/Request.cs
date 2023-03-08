using hmd_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Requests
{
    public abstract class Request : IRequest
    {
        protected abstract string RequestBody();

        public void Execute()
        {
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw(this.RequestBody());
        }

        public virtual void Execute(string[] parameters)
        {
        }
    }
}
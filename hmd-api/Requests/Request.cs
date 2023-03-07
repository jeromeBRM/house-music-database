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
        protected string[] parameters;

        public Request()
        {
        }

        public Request(string[] parameters)
        {
            this.parameters = parameters;
        }

        protected abstract string RequestBody();

        public virtual void Execute()
        {
            HmdAPI.GetInstance().GetDbContext().Database.ExecuteSqlRaw(this.RequestBody());
        }

        public void SetParameters(string[] parameters)
        {
            this.parameters = parameters;
        }
    }
}
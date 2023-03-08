using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Requests
{
    interface IRequest
    {
        public abstract void Execute();
        public abstract void Execute(string[] parameters);
    }
}
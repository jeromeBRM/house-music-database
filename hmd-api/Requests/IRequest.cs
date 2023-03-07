using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Requests
{
    interface IRequest
    {
        public void Execute();
        public void SetParameters(string[] parameters);
    }
}
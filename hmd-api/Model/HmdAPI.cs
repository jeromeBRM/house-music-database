using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public sealed class HmdAPI
    {
        private HmdAPI() { }

        private static HmdAPI instance;

        public static HmdAPI getInstance()
        {
            if (HmdAPI.instance == null)
            {
                HmdAPI.instance = new HmdAPI();
            }
            return HmdAPI.instance;
        }
    }
}
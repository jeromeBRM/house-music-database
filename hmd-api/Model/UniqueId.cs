using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class UniqueId
    {
        private static int idLength = 16;
        private static string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static Random random = new Random();

        public UniqueId()
        {
        }

        public string Get()
        {
            return new String(Enumerable.Repeat(chars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
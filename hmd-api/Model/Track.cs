using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Track : Identifiable
    {
        private string name;
        private HashSet<Author> authors;

        public Track(string name)
        {
            this.name = name;
            this.authors = new HashSet<Author>();
        }

        public Track(string name, HashSet<Author> authors)
        {
            this.name = name;
            this.authors = authors;
        }

        public override string getTableName()
        {
            return new String("hmd-tracks");
        }
    }
}

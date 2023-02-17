using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Author : Identifiable
    {
        private string name;

        public Author(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public override string getTableName()
        {
            return new String("hmd-authors");
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            
            Author author = (Author)obj;

            return this.getName().Equals(author.getName()) || base.Equals(author);
        }
    }
}

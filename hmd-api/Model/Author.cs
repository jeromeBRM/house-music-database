using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public class Author : ApiObject
    {
        private string name;

        public Author(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public override string Type()
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

            return this.GetName().Equals(author.GetName()) || base.Equals(author);
        }
    }
}
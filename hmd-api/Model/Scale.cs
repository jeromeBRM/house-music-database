using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class Scale : Identifiable
    {
        private int value;
        private static int min = 0;
        private static int max = 100;

        public Scale()
        {
            this.setValue(Scale.min);
        }

        public int getValue()
        {
            return this.value;
        }

        public void setValue(int value)
        {
            if (value < Scale.min)
            {
                this.value = Scale.min;
            }
            else if (value > Scale.max)
            {
                this.value = Scale.max;
            }
            else
            {
                this.value = value;
            }
        }

        public abstract string getName();

        public abstract string getDescription();

        public override string getTableName()
        {
            return new String("hmd-scales");
        }
    }
}

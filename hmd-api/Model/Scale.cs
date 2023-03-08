using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmd_api.Model
{
    public abstract class Scale : ApiObject
    {
        private int value;
        private static int min = 0;
        private static int max = 100;

        public Scale()
        {
            this.SetValue(Scale.min);
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int value)
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

        public abstract string GetName();

        public abstract string GetDescription();

        public override string Type()
        {
            return new String("hmd-scales");
        }
    }
}
using System;
using System.Text.Json;

namespace hmd_api.Model
{
    public class Scale : ApiObject
    {
        private int value;
        private static int min = 0;
        private static int max = 100;
        
        public string Name { get { return this.GetName(); } set {  } }

        public int Value { get { return this.value; } set { this.SetValue(value); } }

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

        public virtual string GetName()
        {
            return new String("undefined");
        }

        public virtual string GetDescription()
        {
            return new String("undefined");
        }

        public override void Restore(SQLApiObject sqlApiObject)
        {
            base.Restore(sqlApiObject);

            if (sqlApiObject.value != null)
            {
                Scale trackDatas = JsonSerializer.Deserialize<Scale>(sqlApiObject.value);
                this.Value = trackDatas.Value;
            }
        }

        public override string Type()
        {
            return new String("hmd-scales");
        }
    }
}
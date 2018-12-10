using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Routing
{
    class Vertics : IComparable<Vertics>
    {
        public int Number;
        public float x, y, time;
        public Vertics()
        {
        }
        public Vertics(float t, int num, float x, float y)
        {
            this.Number = num;
            this.x = x;
            this.y = y;
            this.time = t;
        } 
        public int CompareTo(Vertics V)
        {
            if (this.time == V.time)
            {
                return 0;
            }
            else if (this.time < V.time)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public Vertics(Vertics v)
        {
            this.x = v.x;
            this.y = v.y;
            this.Number = v.Number;
            this.time = v.time;
        }
        

    }
}

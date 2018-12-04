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
        public float x, y;
        public Vertics()
        {
        }
        public Vertics(int num , float x , float y)
        {
            this.Number = num;
            this.x = x;
            this.y = y;
        }
        public int CompareTo(Vertics x)
        {
            return this.Number-x.Number;
        }
    }
}

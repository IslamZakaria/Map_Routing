using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;


namespace Map_Routing
{
    public class Edge : IComparable<Edge>
    {
        public int point1, point2;
        public float speed , Length , time;
        public Edge()
        {
            this.speed = 0;
            this.Length = 0;
        }
        public Edge(int p1, int p2, float Length, float speed)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.speed = speed;
            this.Length = Length;
            this.time = this.Length / this.speed;
        }
        public int CompareTo(Edge E)
        {
            return 0;
        }
    }
}

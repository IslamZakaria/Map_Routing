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
    class Person
    {
        public Vertics source, distnation;
        public int R , speed;
        public Person()
        {
            source = new Vertics();
            distnation = new Vertics();
            this.speed = 5;
            this.R = 0;
        }
        public Person(Vertics source , Vertics dist , int R)
        {
            this.source = source;
            this.distnation = dist;
            this.speed = 5;
            this.R = R;
        }
    }
}

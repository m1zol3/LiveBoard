using System;
using System.Collections.Generic;
using System.Text;

namespace LiveBoard
{
     class Distanz
    {
        public Distanz() { }
        public Distanz(int a, int b)
        {
            WeiteA = a;
            WeiteB = b;
        }
        public int WeiteA { get; set; }
        public int WeiteB { get; set; }
    }
}

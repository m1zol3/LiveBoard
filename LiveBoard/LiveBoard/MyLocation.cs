using System;
using System.Collections.Generic;
using System.Text;

namespace LiveBoard
{
    class MyLocation
    {
        public MyLocation() { }
        public MyLocation(float x, float y)
        {
            AnfangX = x;
            AnfangY = y;
          
        }
        public float AnfangX { get; set; }
        public float AnfangY { get; set; }
        public override string ToString()
        {
            return "Anfang X: " + AnfangX + " Anfang Y: " + AnfangY;
        }
    }
}

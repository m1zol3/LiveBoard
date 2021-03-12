using System;
using System.Collections.Generic;
using System.Text;

namespace LiveBoard
{
    class MyStoringLocation
    {
        public MyStoringLocation() { }
        public MyStoringLocation(float x, float y, float xE, float yE)
        {
            AnfangX = x;
            AnfangY = y;
            EndeX = xE;
            EndeY = yE;
        }
        public float AnfangX { get; set; }
        public float AnfangY { get; set; }
        public float EndeY { get; set; }
        public float EndeX { get; set; }
        public override string ToString()
        {
            return "Anfang X: " + AnfangX + " Anfang Y: " + AnfangY + " Ende X: " + EndeX + " Ende Y: " + EndeY;
        }
    }
}

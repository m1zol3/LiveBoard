using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace LiveBoard.TouchTracking
{

    public class DragInfo
    {
        public long Id { get; private set; }
        public Point PressPoint { get; private set; }

        public DragInfo(long id, Point pressPoint)
        {
            Id = id;
            PressPoint = pressPoint;
        }
    }
}

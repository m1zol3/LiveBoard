using System;
using System.Collections.Generic;
using System.Text;

namespace LiveBoard
{
    class MyUndo
    {
        public MyUndo() { }
        public MyUndo(int a, int b)
        {
            Id=a;
            Zahl = b;
        }
        public int Id { get; set; }
        public int Zahl { get; set; }
        
    }
}

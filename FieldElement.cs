using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;

namespace Logic
{
    class FieldElement //клеточка в таблице (из которой так же состоят фигуры)
    {
        public int x { get; set; }
        public int y { get; set; }
        public Color  color { get; set; }
        public FieldElement (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public FieldElement (int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}

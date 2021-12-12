using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace t3tr1s.Figures
{
    class FigureZ : Figure
    {
        public override void Generate(int x, int y)
        {
            x--;
            Elements.Add(new FieldElement(x, y));
            Elements.Add(new FieldElement(x + 1, y));
            Elements.Add(new FieldElement(x + 1, y + 1));
            Elements.Add(new FieldElement(x + 2, y + 1));
            SetColor(Colors.Green);
        }
    };
}

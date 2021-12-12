using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace t3tr1s.Figures
{
    class FigureJ : Figure
    {
        public override void Generate(int x, int y)
        {
            x--;
            y++;
            Elements.Add(new FieldElement(x, y));
            Elements.Add(new FieldElement(x + 1, y));
            Elements.Add(new FieldElement(x + 2, y));
            Elements.Add(new FieldElement(x, y - 1));
            SetColor(Colors.Pink);
        }
    };
}

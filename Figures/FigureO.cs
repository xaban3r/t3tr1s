using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace t3tr1s.Figures
{
    public class FigureO : Figure, IFigure
    {
        public void Generate(int x, int y)
        {
            elements.Add(new FieldElement(x, y));
            elements.Add(new FieldElement(x + 1, y));
            elements.Add(new FieldElement(x, y + 1));
            elements.Add(new FieldElement(x + 1, y + 1));
            SetColor(Colors.Yellow);
        }
    };
}


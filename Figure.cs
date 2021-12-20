using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace t3tr1s
{
    public class Figure
    {
        private List<FieldElement> elements  = new List<FieldElement>();              
        public List<FieldElement> Elements { get { return elements; } }             // свойство
        private readonly List<Color> color = new List<Color> { Colors.Red, Colors.Yellow, Colors.Green, Colors.Blue };
        private readonly Random random = new Random();

        public void SetRandomColor()
        {
            int i = random.Next(0, color.Count);
            Color col = color[i];
            elements.ForEach(element => element.color = col);                         // читается как переходит в 
        }
        public void SetColor(Color color)
        {
            elements.ForEach(element => element.color = color);
        }

        bool move { get; set; }
        public Figure() { move = true; }



        public virtual void Generate(int x, int y) { }
     
        



        /*==========================================*/
        /*обработка движений и столкновений*/

        public bool RightMove(List<FieldElement> listOfFallenElements)                       // метод .Exists(Predicate<T> pr)  (существует ли элемент)
        {                                                                                    // с помощью лямбда-выражения проходиться по элементам листа
            //move = true;                                                                   // и возвращает последний элемент, координата х которого является
            if (!elements.Exists(element => (element.x + 1) == Game.Columns))                // последней, x+1 т.к свойство Columns возвращает 10 
            {
                if (!listOfFallenElements.Exists(lofe => elements.Exists(element => (element.x + 1) == lofe.x && element.y == lofe.y)))
                {
                    elements.ForEach(element => element.x++);
                }
            }
            return move;
        }


        public bool LeftMove(List<FieldElement> listOfFallenElements)
        {
            //move = true;                                                                 
            if (!elements.Exists(element => (element.x - 1) < 0))
            {
                if (!listOfFallenElements.Exists(lofe => elements.Exists(element => (element.x - 1) == lofe.x && element.y == lofe.y)))
                {
                    elements.ForEach(element => element.x--);
                }
            }
            return move;
        }

        public bool DownMove(List<FieldElement> listOfFallenElements)
        {
            if (!elements.Exists(element => (element.y + 1) == Game.Rows))
            {
                if (listOfFallenElements.Exists(lofe => elements.Exists(element => (element.y + 1) == lofe.y && element.x == lofe.x)))
                    move = false;
                else
                {
                    elements.ForEach(element => element.y++);
                    move = true;
                }                    
            }
            else move = false;

            return move;


        }


        public bool Rotate(List<FieldElement> listOfElements)
        {
            List<FieldElement> testElements = new List<FieldElement>(elements.Count());

            int xMax = (elements.Max(el => el.x));
            int yMax = (elements.Max(el => el.y));
            int xMin = (elements.Min(el => el.x));
            int yMin = (elements.Min(el => el.y));
            int xlenth = xMax - xMin + 1;
            int ylenth = yMax - yMin + 1;

            if (xlenth > ylenth) xMin++;
            if (ylenth > xlenth) xMin--;

            foreach (FieldElement el in elements)
            {
                testElements.Add(new FieldElement(Math.Abs(el.y - yMax) + xMin, (el.x - xMin) + yMin, el.color));
            }

            if (!(listOfElements.Exists(lo => testElements.Exists(el => (el.y == lo.y && el.x == lo.x) || el.x < 0 || el.y < 0 || el.x >= Game.Columns || el.y >= Game.Rows || el.y < 0 || el.x < 0))))
            {
                elements.Clear();
                elements.AddRange(testElements);
            }
            return true;
            /*List<FieldElement> testElements = new List<FieldElement>(elements.Count());
            int xMax = elements.Max(el => el.x);
            int yMax = elements.Max(el => el.y);
            int xMin = (elements.Min(el => el.x));
            int yMin = (elements.Min(el => el.y));
            int xlength = xMax - xMin;
            int ylength = yMax - yMin;

            int me = (xlength > ylength) ? xlength + 1 : ylength + 1;

            foreach (FieldElement el in elements)
            {
                testElements.Add(new FieldElement(el.y, 1 - (el.x - (me - 2)), el.color));
            }

            if (!(listOfElements.Exists(lo => testElements.Exists(el => (el.y == lo.y && el.x == lo.x) || el.x < 0 || el.y < 0 || el.x >= Game.Columns || el.y >= Game.Rows || el.y < 0 || el.x < 0))))
            {
                elements.Clear();
                elements.AddRange(testElements);
            }
            return true;*/
        }
        


        public bool Collision(List<FieldElement> listOfFallenElements)
        {
            return (listOfFallenElements.Exists(lofe => elements.Exists(el => el.x == lofe.x && el.y == lofe.y)));
        }
    }
}
